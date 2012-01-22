using System;
using System.Collections;
using System.Collections.Generic;

namespace DevelopStuff.EvolveStuff.Core
{
	public static class InternalExtensions
	{
		public static T First<T>(this List<T> things)
		{
			return things[0];
		}
	}
}

