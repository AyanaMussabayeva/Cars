using System;

namespace Cars
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			//Menu menu = new Menu();
			Console.CursorVisible = false;

			//Console.SetBufferSize(Global.Width, Global.Height);
			Scene scene = new Scene();

			scene.AddInitialCar();
			scene.Run();
			Action action = new Action();
			action.Attach(scene);

			action.makeAction(scene);

		}
	}
}
