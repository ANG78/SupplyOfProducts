using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplyOfProducts.Api.Common;
using System;
using System.Windows.Forms;

namespace SupplyOfProducts.WF3._0
{

   
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var conf = new ConfigurationBuilder();
            conf.AddJsonFile("appsettings");

            var services = new ServiceCollection();


            Startup start = new Startup(conf.Build());
            start.ConfigureRepositoryServices(services);
            
            var helper = HI.GetInst(services.BuildServiceProvider());

            var mainForm = new FrmMain();
            IObserverEvent observer = new FrmMainObserver(mainForm);
            CoRBuilder.Listener?.Register(observer);

            Application.Run(mainForm);
        }
    }
}



