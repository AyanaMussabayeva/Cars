using System;
namespace Cars
{
	public class Wall
	{
		public Wall()
		{
			
		}
		public char signOfWall = '|';
		public ConsoleColor wallColor = ConsoleColor.DarkGreen;
		public void WallRedraw()
		{

			for (int i = 0; i < Global.Height; i++)
			{
				Console.SetCursorPosition(Global.Width+1, i);
				Console.Write(signOfWall);
				Console.ForegroundColor = wallColor;
			}
			for (int i = 0; i < Global.Height; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.Write(signOfWall);
				Console.ForegroundColor = wallColor;
			}
		}
	}
}
