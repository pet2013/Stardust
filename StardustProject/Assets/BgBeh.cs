using UnityEngine;
using System.Collections;

public class BgBeh : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 100)) {

		}
	}

	void OnMouseDown()
	{
		//Debug.Log (Input.mousePosition);
	}
}
