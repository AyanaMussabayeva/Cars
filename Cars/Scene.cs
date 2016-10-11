using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;



namespace Cars
{
	public class Scene : IObserver
	{
		public Scene()
		{
		}

		public bool GameActive = true;
		public int pointsCount=0, lvlCount=1;
		public Car clonableCar = new Car(0, 0, ConsoleColor.Cyan);
		public int cloneCarTime=10;
		public int cloneCarCnt = 0;
		public int currentSpeed = Global.speed;
		public List<Car> cars = new List<Car>();

		public void AddInitialCar()
		{
			cars.Add(new Car(Global.middleRoad, 10, ConsoleColor.Magenta));
		}

		public void Run()
		{
			Thread t = new Thread(new ThreadStart(Iteration));
			t.Start();
		}
		private void Iteration()
		{
			while (true)
			{
				ChangeScene();
				Thread.Sleep(currentSpeed);
			}
		}
		private void ChangeScene()
		{
			
			Console.Clear();
			CheckCoordinates();
			foreach (Car c in cars)
			{
				c.Redraw();

			}
			for (int i = 1; i < cars.Count; i++)
			{
				cars[i].GoUp();


			}
			Wall wall = new Wall();
			wall.WallRedraw();

			CloneHandler();
			ShowLvl();

		}
		public void DeleteCar()
		{
			for (int i = 1; i < cars.Count; i++)
			{
				if (cars[i].y > Global.Height)
				{
					cars.Remove(cars[i]);
				}
				if (cars[i].y > cars[0].y)
				{
					pointsCount++;
				}
			}

		}

		public void ShowLvl()
		{
			Console.SetCursorPosition(10, 0);
			Console.WriteLine("Points: " + pointsCount.ToString());
			Console.SetCursorPosition(10, 1);
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("Level: " + lvlCount.ToString());
		}
		public void CheckCoordinates()
		{
			for (int i = 1; i < cars.Count; i++)
			{

				if (cars[0].x == cars[i].x && cars[0].y == cars[i].y || cars[0].x <1 || cars[0].x >6)
				{
					Console.WriteLine("GAME OVER");
					GameActive = false;
					Thread.Sleep(500);
					Thread.ResetAbort();
				}
			}
			DeleteCar();
		}

		public void CloneHandler()
		{
			
			cloneCarCnt++;
			if (cloneCarCnt == cloneCarTime)
			{
				if (cars.Count < 3)
				{

					Car clonedCar = clonableCar.Clone();
					if (clonedCar.x == cars[cars.Count - 1].x)
					{
						if (clonedCar.x == 4)
						{
							clonedCar.x = 1;
						}
						else {
							clonedCar.x = 4;
						}
					}
					lock (cars)
					{
						cars.Add(clonedCar);
						cloneCarCnt = 0;
					}
				}

			}


		}


		public void SpeedUp()
		{
			ConsoleColor[] newColors = { ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Gray, ConsoleColor.DarkCyan, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Red };
			Random rand = new Random();
			if (pointsCount > 100)
			{
				pointsCount = 0;
				lvlCount++;
				currentSpeed += Global.speedInc;
				for (int i = 1; i < cars.Count; i++)
				{
					cars[i].colorOfCar = newColors[rand.Next(newColors.Length)];

				}
			}


		}
			                               
			
	}
}
