using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elite_Dangerous_RPG_Overlay
{
    public class SplashScreen
    {
        public static void ShowSplash()
        {
            Form splash = new Form
            {
                Size = new Size(600, 300),
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.Black
            };

            Label splashLabel = new Label
            {
                Text = "Cargando Elite Dangerous RPG Overlay...",
                ForeColor = Color.White,
                Font = new Font("Poppins SemiBold", 14),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            splash.Controls.Add(splashLabel);
            splash.Show();
            Application.DoEvents();

            var splashTimer = new System.Windows.Forms.Timer { Interval = 3000 };
            splashTimer.Tick += (sender, e) =>
            {
                splash.Close();
                splashTimer.Stop();
            };
            splashTimer.Start();
        }
    }
}
