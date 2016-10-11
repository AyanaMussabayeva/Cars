using System;
using System.Collections.Generic;

namespace Cars
{
	public class CarForm
	{
		public CarForm()
		{
		}

		public static char[,] carForm = {{ 'O', '-', 'O' },
										{ ':', '-', ':' },
										{ 'O', '-', 'O' } };
		public static char[,] carForm1 = {{ 'o', '_', 'o' },
										{ '|', '|', '|' },
										{ 'o', '-', 'o' } };
		public static char[,] carForm3 = {{ 'o', '_', 'o' },
										  { '|', 'X', '|' },
										  { 'O', '-', 'O' } };
		public static char[,] carForm4 = {{ '@', '_', '@' },
										  { '[', 'T', ']' },
										  { '@', '-', '@' } };
		public List<char[,]> carForms = new List<char[,]>() { carForm, carForm1, carForm3, carForm4 };
		
	}
}
