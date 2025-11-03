using System;
using System.Windows.Forms;

namespace File_Binder
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);

			// Show splash screen first with "Cracked by unknown hart"
			SplashScreen splash = new SplashScreen();
			splash.ShowDialog();

			// Then run main application
			Application.Run(new FileBinderForm());
		}
	}
}
