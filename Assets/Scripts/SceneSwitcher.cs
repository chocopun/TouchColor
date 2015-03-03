using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void SwitchToMain(){
		Application.LoadLevel("Main");
	}

	public void SwitchToMenu() {
		Application.LoadLevel("Menu");
	}
}
