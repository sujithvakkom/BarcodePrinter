using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace BarCodePrinter
{
    static class Program
    {
        public static
            List<Thread> ThreadPool;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ThreadPool = new List<Thread>();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new barcodePrinterForm());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            GC.Collect();
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            foreach(Thread thread in ThreadPool){
                if (thread.IsAlive)
                {
                    thread.Abort();
                }
            }
        }
    }
}