using UnityEngine;
using System.Collections;

public class MainMenuBeh : MonoBehaviour {
	GameObject background;
	public Camera[] cameras;
	private int currentCamera = 0;

	void Start(){
		background = GameObject.Find("MainMenuBg");
		SwitchCamera(0, true);
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

	// Update is called once per frame
	void Update () {
		AnimateBackground ();
	}

	void AnimateBackground(){
		background.transform.Rotate(Vector3.forward,1*Time.deltaTime);
	}

}