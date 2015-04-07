using System;
using Gtk;
using YABDL.Views;

namespace YABDL
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init();
			var mainWindow = new MainWindow ();
            mainWindow.Show();
			Application.Run();
		}
	}
}
