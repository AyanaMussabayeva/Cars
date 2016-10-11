using System;
namespace Cars
{
	public class Action : Subject
	{
		public Action()
		{
		}
		public void makeAction(Scene scene)
		{
			while (scene.GameActive == true){

				//checkPoints();

				ConsoleKeyInfo pressedKey = Console.ReadKey();
				switch (pressedKey.Key)
				{
					case ConsoleKey.Enter:
						//	scene.ChooseCar();
						scene.cars[0].changeCar();
					 	break;
					
					case ConsoleKey.LeftArrow:
						//if (scene.pointsCount == 100)
						//{
						//	scene.pointsCount = 0;
							Notify();
						//}
						scene.cars[0].LeftRight();
						break;
					case ConsoleKey.RightArrow:


							Notify();

						scene.cars[0].Right();
						break;
						
					//case ConsoleKey.S:
					//	scene.GameActive = true;
					//	break;

					

				}

			}
		}

			
	}
}
