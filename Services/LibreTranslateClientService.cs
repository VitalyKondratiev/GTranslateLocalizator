using GTranslateLocalizatorApp.Structures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GTranslateLocalizatorApp.Services
{
    public class LibreTranslateClientService
    {
        private static readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://trans.zillyhuhn.com") // see https://github.com/LibreTranslate/LibreTranslate#mirrors
        };

        public static LibreLanguage[] GetLanguages()
        {
            var response = _httpClient.Send(new HttpRequestMessage(HttpMethod.Get, "/languages"));
            if (response.IsSuccessStatusCode)
            {
                LibreLanguage[] languages = JsonConvert.DeserializeObject<LibreLanguage[]>(response.Content.ReadAsStringAsync().Result);
                return languages;
            }

            return new LibreLanguage[] { };
        }


        public async Task<string[]> TranslateAsync(TranslationTask task, bool afterSleep = false)
        {
            var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/translate", content);

            if (response.IsSuccessStatusCode)
            {
                TranslatedStrings translated = JsonConvert.DeserializeObject<TranslatedStrings>(await response.Content.ReadAsStringAsync());
                return translated.translatedText;
            }

            if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests && !afterSleep)
            {
                Thread.Sleep(10000);
                return await TranslateAsync(task, true);
            }
            return default(string[]);
        }
    }
}
