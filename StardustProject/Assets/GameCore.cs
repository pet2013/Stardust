using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AssemblyCSharp
{
	public class GameCore
	{
		private List<GameLevel> Levels;

		private GameLevel CurrentLevel;

		public GameCore ()
		{
			Levels = new List<GameLevel> ();
			Levels.Add (FirstLevel ());

			CurrentLevel = Levels.First ();
		}

		private GameLevel FirstLevel()
		{
			var gl = new GameLevel ();

			return gl;
		}


		public void Tick()
		{
			MoveRockets();
			MovePlanets();
			RotatePlanets();
		}
		
		void MoveRockets()
		{
			foreach (var rocket in CurrentLevel.Rockets) 
			{
				
				//Debug.Log (rocket.transform.position);
				
				var speed = 1f;
				var angle = 0f;
				var force = GetRocketForce(rocket);
				angle = force;
				
				rocket.transform.Translate(Vector3.up*speed*Time.deltaTime);
				rocket.transform.Rotate(Vector3.forward, angle*Time.deltaTime);
			}
		}


		void MovePlanets()
		{

		}
		
		void RotatePlanets()
		{

		}
		
		float GetForce(GameObject a, GameObject b)
		{
			var force = 0f;
			//Debug.Log (a.transform.position);
			//Debug.Log (b.transform.up);
			var targetDir = b.transform.position - a.transform.position;
			var forward =  a.transform.up;
			var angle = Vector3.Angle(targetDir, forward);
			var cross = Vector3.Cross (targetDir, forward);
			if (cross.z < 0)
				angle = -angle;
			var sin = Mathf.Sin (Mathf.PI * angle / 180.0f);
			var r2 = Vector3.Distance (a.transform.position, b.transform.position)*10;
			if (r2<1)
				return 0;//collision
			var g = 2000;
			var res = sin*g/(r2*r2);
			//Debug.Log (sin);
			return -res;
		}
		
		float GetRocketForce(GameObject rocket)
		{
			float totalForce = 0;

			
			return totalForce;
			
		}
	}
}

