﻿using System;
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
            Application.Run(new MainForm());
        }
    }
}