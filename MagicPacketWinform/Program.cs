using System;
using System.Windows.Forms;

namespace MagicPacketWinform
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //DotNet Framework
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //DotNet 5.0 or later
            //ApplicationConfiguration.Initialize();

            Application.Run(new Form1());
        }
    }
}