using UnityEngine;
using System.Collections;

public class OnMenuItemClick : MonoBehaviour {
	public Camera[] cameras;
	private int currentCamera = 0;
	
	void OnClick(){
		switch(this.name){
			case "bStart": 
				StartGame ();
				break;
			case "bOptions": 
				RunOptionsMenu ();
				break;
			case "bExit": 
				ExitGame ();
				break;
			case "bOptionsBack": 
				CloseOptionsMenu ();
				break;
		}
	}

	void SwitchCamera (int num, bool direct) {
		if (direct){
			currentCamera = num;
		}else{
			currentCamera=(currentCamera+num)%cameras.Length;
		}
		for (var i = 0; i<cameras.Length; i++) {
			cameras[i].enabled = (i==currentCamera);
		}
	}

	//Options menu functions
	void CloseOptionsMenu () {
		SwitchCamera(0, true);
	}
	
	// Main menu functions
	void StartGame () {
		Application.LoadLevel(1);
	}
	
	void RunOptionsMenu () {
		SwitchCamera(1, true);
	}
	
	void ExitGame () {
		Application.Quit();
	}
}