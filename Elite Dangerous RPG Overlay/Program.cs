using System;
using System.Windows.Forms;

namespace Elite_Dangerous_RPG_Overlay
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreen.ShowSplash(); // Llamar al Splash Screen
            Application.Run(new Form1());
        }
    }
}
