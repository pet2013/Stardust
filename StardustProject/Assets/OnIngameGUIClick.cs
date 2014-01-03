using UnityEngine;
using System.Collections;

public class OnIngameGUIClick : MonoBehaviour {

	private GameObject PlanetInfoPanel;

	void Start(){
		PlanetInfoPanel = GameObject.Find ("PlanetInfo");
	}

	void OnClick(){
		switch(this.name){
			case "sPlanetInfoClose": 
				PlanetInfoClose();
			break;
		}
	}

	void PlanetInfoClose(){
		PlanetInfoPanel.SetActive (false);
	}
}
