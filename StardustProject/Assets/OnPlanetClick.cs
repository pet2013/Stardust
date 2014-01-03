using UnityEngine;
using System.Collections;

public class OnPlanetClick : MonoBehaviour {
	
	public GameObject PlanetInfoPanel;

	//void Start(){
		//PlanetName = GameObject.Find("lPlanetName");
	//}
	
	void OnMouseDown(){
		PlanetInfoPanel.SetActive(true);

		//Debug.Log (PlanetInfoPanel.name);
	}
}