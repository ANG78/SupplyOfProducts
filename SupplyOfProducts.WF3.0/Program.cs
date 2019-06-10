using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.Api.Common;
using System;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{
    static class Program
    {

        public static System.Threading.SynchronizationContext SynchronizationContext { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var conf = new ConfigurationBuilder();
            conf.AddJsonFile("appsettings.json");

            var services = new ServiceCollection();
            Startup start = new Startup(conf.Build());
            start.ConfigureRepositoryServices(services);

            var ProviderDB = services.BuildServiceProvider();

            Application.Run(new FrmMain());
        }
    }
}
