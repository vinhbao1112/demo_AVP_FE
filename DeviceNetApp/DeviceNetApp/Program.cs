using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace DeviceNetApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Check app already run
            bool ok;
            Mutex m = new Mutex(true, @"Global\DeviceNetAppMutex", out ok);
            if (!ok)
            {
                MessageBox.Show("Another instance is already running.");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DeviceNetApp());
            GC.KeepAlive(m);
        }
    }
}