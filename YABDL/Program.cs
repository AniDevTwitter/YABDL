using System;
using YABDL.Views;
using Gtk;

namespace YABDL
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init();
			var mainWindow = new MainWindow ();
            mainWindow.ShowAll();
			Application.Run();
		}
	}
}
