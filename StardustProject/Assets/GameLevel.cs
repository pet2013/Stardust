using System;
using System.Collections.Generic;
using UnityEngine;
 

namespace AssemblyCSharp
{
	public class GameLevel
	{
		public List<GameObject> SpaceObects;
		public List<GameObject> Planets;
		public List<GameObject> Rockets;

		public GameLevel ()
		{
			SpaceObects = new List<GameObject> ();
			Planets = new List<GameObject> ();
			Rockets = new List<GameObject> ();


		}




	}
}

