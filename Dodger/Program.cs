using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Dodger.Handlers;
using Dodger.Infrastructure;

namespace Dodger
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            InitWindowsForms();
        }

        private static void InitWindowsForms()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}