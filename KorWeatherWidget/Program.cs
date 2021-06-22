using System;
using System.Windows.Forms;

namespace WeatherWidget {
    static class Program {
        [STAThread]
        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmWidget());
        }
    }
}
