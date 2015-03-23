using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Profile : MonoBehaviour {
	Text nameText;
	InputField nameInputField;
	private string playerName;

	// Use this for initialization
	void Start () {
		nameText = GameObject.Find("NameText").GetComponent<Text>();
		nameInputField = GameObject.Find("NameInputField").GetComponent<InputField>();
		playerName = PlayerPrefs.GetString("playerName");
		ChangeName(playerName);
	}

	// Update is called once per frame
	void Update () {
	}

	void ChangeName(string name){
		nameText.text = name;
		PlayerPrefs.SetString("playerName", name);
	}

	public void SubmitButton(){
		ChangeName(nameInputField.text);
	}
}
