using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour {
	private string lastScene;

	void Start () {
		lastScene = PlayerPrefs.GetString("lastScene");
	}

	void Update () {

	}

	public void SwitchBack(){
		Application.LoadLevel(lastScene);
	}

	public void SwitchToMain(){
		Application.LoadLevel("Main");
	}

	public void SwitchToMenu() {
		Application.LoadLevel("Menu");
	}

	public void SwitchToRanking() {
		Application.LoadLevel("Ranking");
	}

	public void SwitchToProfile() {
		Application.LoadLevel("Profile");
	}

	public void SwitchReady(){
		Application.LoadLevel("Ready");
	}

	public void SwitchResult(){
		Application.LoadLevel("Result");
	}
}
