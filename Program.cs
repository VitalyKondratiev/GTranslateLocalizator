using GTranslateLocalizatorApp.Services;
using GTranslateLocalizatorApp.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GTranslateLocalizatorApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IHost host = CreateHostBuilder().Build();
            IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider services = serviceScope.ServiceProvider;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(services.GetRequiredService<mainForm>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddScoped<ITranslationLibraryService, TranslationLibraryService>();
                    services.AddScoped<IFileXmlService, FileXmlService>();
                    services.AddScoped<mainForm>();
                });
        }
    }
}