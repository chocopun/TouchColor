using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InsertDB : MonoBehaviour {
	private Wrapper w;
	private	Dictionary<string, string> form = new Dictionary<string, string>();
	public string url = "chnr.wc.lt/input.php";
	private string playerName;
	private int lastScore;

	void Start () {
		w = GameObject.Find("Wrapper").GetComponent<Wrapper>();
		playerName = PlayerPrefs.GetString("playerName");
		lastScore = PlayerPrefs.GetInt("lastScore");
		Debug.Log("PlayerName:" + playerName);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Insert() {
		if(playerName!=null){
			form.Add("name", playerName);
		}else{
			form.Add("name", "ゲスト");
		}
		form.Add("score", lastScore.ToString());
		//WWW results = w.GET(url);
		WWW results = w.POST(url, form);
		Debug.Log("post:"+url);

	}
}
