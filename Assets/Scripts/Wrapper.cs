using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Wrapper : MonoBehaviour {
	public Button registButton;
	public Text registText;

	void Awake() {
		registButton = GameObject.Find("RegistButton").GetComponent<Button>();
		registText = GameObject.Find("RegistText").GetComponent<Text>();
	}

	public WWW GET(string url) {
		WWW www = new WWW (url);
		StartCoroutine (WaitForRequest (www));
		return www;
	}
	public WWW POST(string url, Dictionary<string,string> post) {
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<string,string> post_arg in post) {
			form.AddField(post_arg.Key, post_arg.Value);
		}
		WWW www = new WWW(url, form);
		StartCoroutine("WaitForRequest", www);
		Debug.Log("post complete");
		return www;
	}
	public IEnumerator WaitForRequest(WWW www) {
		registText.text = "ランキングに登録しています...";
		registButton.gameObject.SetActive(true);
		Debug.Log("check for www error");
		yield return www;
		// check for errors
		if (www.error == null) {
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
		registText.text = "ランキングに登録しました!";
		GameObject.Find("Canvas").GetComponent<Result>().download = true;
	}
}
