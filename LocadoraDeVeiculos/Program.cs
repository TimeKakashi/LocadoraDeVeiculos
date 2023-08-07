using FluentValidation;
using Serilog;
using System.Globalization;

namespace LocadoraDeVeiculos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("pt-BR");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();



            Application.Run(new TelaPrincipal());
        }
    }
}