using Chat.BL;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.PL
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            NinjectModule repomodule = new RepoModule();
            NinjectModule servicemodule = new ServiceModule();
            var kernel = new StandardKernel(servicemodule,repomodule);
            Application.Run(kernel.Get<Form1>());
        }
    }
}
