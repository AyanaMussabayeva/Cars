using System;
namespace Cars
{
	public class Car : IClonable
	{
		
		public Car()
		{
		}
		public char[,] currentCarForm = {{ '0', '_', '0' },
									{ '+', '-', '+' },
										{ '0', '-', '0' } };
		public ConsoleColor colorOfCar { get; set;}

		public int x, y, dx = 1, dy = 1, speed;
		//public char[,] carForm = {{ '0', '_', '0' },
		//								{ '+', '-', '+' },
		//								{ '0', '-', '0' } };
		CarForm myCarForm = new CarForm();

		public void changeCar()
		{
			Random randomCar = new Random();
			currentCarForm = myCarForm.carForms[randomCar.Next(myCarForm.carForms.Count)];
		}
				
		public void LeftRight()
		{
			
			x -= Global.step;
		}
		public void Right()
		{
			x += Global.step;
		}
		public void GoUp() 
		{
			y += Global.CarSpeed;
		}
		public void Redraw()
		{

			Console.ForegroundColor = colorOfCar;
			Console.SetCursorPosition(x, y);
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (y + i < 22)
					{

						Console.SetCursorPosition(x + j, y + i);
						char symbol = currentCarForm[i, j];
						Console.Write(symbol);
					}
					else {
						y = 0;
					}
				}
			}

		}


		public Car(int x, int y)
		{
			this.x = x;
			this.y = y;

		}
		//public Car(int x, int y, char[,,] carForm)
		//{
		//	this.x = x;
		//	this.y = y;
		//	this.carForm = carForm;

		//}
		public Car(int x, int y, ConsoleColor colorOfCar)
		{
			this.x = x;
			this.y = y;
			this.colorOfCar = colorOfCar;
		}
		public Car Clone()
		{
			int[] xs= { Global.beginningRoad, Global.middleRoad};
			ConsoleColor[] carColors = { ConsoleColor.White, ConsoleColor.Yellow , ConsoleColor.Cyan};
			Random rand = new Random();
			int randomX = xs[rand.Next(xs.Length)];

			ConsoleColor randomColor = carColors[rand.Next(carColors.Length)];

			Car newCar = new Car(randomX, 0, randomColor);
			return newCar;
		}
	}
}
