using System;
using System.Collections.Generic;
namespace Cars
{
	public abstract class Subject
	{
		public Subject()
		{
		}
		List <IObserver> observers = new List <IObserver>();
		public void Attach(IObserver o)
		{
			observers.Add(o);
		}
		public void Notify()
		{
			
			foreach (IObserver o in observers)
			{
				o.SpeedUp();
			}
		}
	}
}
