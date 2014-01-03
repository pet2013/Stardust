using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameBeh : MonoBehaviour {

	GameObject sun;
	GameObject mars;
	GameObject moon;
	GameObject earth;
	GameObject jupiter;
	GameObject cyclone;

	public List<GameObject> Rockets;
	List<GameObject> Planets;

	List<GameObject> SpaceObjects;

	GameObject rocketP;

	// Use this for initialization
	void Start () {

		rocketP = Resources.Load ("RocketF") as GameObject;

		earth = GameObject.Find ("Earth");
		mars = GameObject.Find ("Mars");
		moon = GameObject.Find ("Moon");
		jupiter = GameObject.Find ("Jupiter");
		sun = GameObject.Find ("Sun");
		cyclone = GameObject.Find ("Cyclone");

		Rockets = new List<GameObject> ();
		SpaceObjects = new List<GameObject> ();
		SpaceObjects.Add (sun);
		SpaceObjects.Add (jupiter);
		SpaceObjects.Add (mars);
		SpaceObjects.Add (cyclone);

		Game.Beh = this;
	}

	void OnGUI()
	{
		//if (GUI.Button (new Rect (10, 10, 200, 50), "Launch"))
		//	Launch (new Vector3());
		if (GUI.Button (new Rect (10, Screen.height-60, 200, 50), "Back to main menu"))
			Application.LoadLevel("MainMenu");

		
		//OnMouseDown ();
	}

	void Launch(Vector3 point)
	{
		var rP = rocketP;
		var r = Instantiate (rP) as GameObject;
		r.transform.position = earth.transform.position;
		var a = point - r.transform.position;
		var f = r.transform.up;
		var angle = Vector3.Angle (a,f);
		var cross = Vector3.Cross (a,f);
		//Debug.Log (angle);
		if (cross.z>0)
			angle = -angle;
		r.transform.Rotate (Vector3.forward, angle);
		Rockets.Add (r);
	}
	
	// Update is called once per frame
	void Update () {
		MoveRockets ();
		MovePlanets ();
		RotatePlanets ();

		OnMouseDown ();
	}

	void MoveRockets()
	{
		foreach (var rocket in Rockets) 
		{
			var speed = 1f;
			var angle = 0f;
			var force = GetRocketForce(rocket);
			angle = force;

			rocket.transform.Translate(Vector3.up*speed*Time.deltaTime);
			rocket.transform.Rotate(Vector3.forward, angle*Time.deltaTime);
		}
	}

	void OnMouseDown()
	{
		if (Input.GetMouseButtonUp (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit,20))
			{
				string objectTag = hit.collider.tag;
				string objectName = hit.collider.name;
				Debug.Log(objectTag);
				//Debug.Log(hit.point.x);
				var p = ray.GetPoint(20);
				p.z = 0;
				//Debug.Log(hit.collider.name);
				Debug.DrawLine (transform.position, ray.GetPoint(20), Color.cyan);
				//Debug.Log(p);
				if(objectTag != "SpaceObject"){
					Launch(hit.point);
				}
			}
		}
	}
	
	void MovePlanets()
	{
		moon.transform.RotateAround (earth.transform.position, Vector3.up, 25 * Time.deltaTime);
		moon.transform.RotateAround (earth.transform.position, Vector3.left, 25 * Time.deltaTime);

		earth.transform.RotateAround (sun.transform.position, Vector3.forward, 1 * Time.deltaTime);
		mars.transform.RotateAround (sun.transform.position, Vector3.forward, -1 * Time.deltaTime);
		jupiter.transform.RotateAround (sun.transform.position, Vector3.forward, 1 * Time.deltaTime);
		cyclone.transform.RotateAround (sun.transform.position, Vector3.forward, 1 * Time.deltaTime);
	}

	void RotatePlanets()
	{
		earth.transform.Rotate(Vector3.up,10*Time.deltaTime);
		earth.transform.Rotate(Vector3.right,10*Time.deltaTime);
		jupiter.transform.Rotate(Vector3.forward,3*Time.deltaTime);
		//jupiter.transform.Rotate(Vector3.right,3*Time.deltaTime);
		mars.transform.Rotate(Vector3.up,3*Time.deltaTime);
		//mars.transform.Rotate(Vector3.right,3*Time.deltaTime);
	}

	float GetForce(GameObject a, GameObject b)
	{
		var force = 0f;

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

		foreach (var spaceObject in SpaceObjects) 
		{
			totalForce += GetForce(rocket, spaceObject);
		}

		return totalForce;

	}

	public void Remove(GameObject g)
	{
		Rockets.Remove (g);
		Destroy (g);
	}
}
public class Game
{
	public static GameBeh Beh;

	public static void Remove(GameObject g)
	{
		Beh.Remove (g);

	}
}