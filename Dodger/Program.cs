using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.Run(new Form1());
        }
    }
}