using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ready : MonoBehaviour {
	public Text countdownText;
	private float countdownTime = 3.0f;

	// Use this for initialization
	void Start () {
		countdownText = GameObject.Find("CountDownText").GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		if(countdownTime > 2){
			countdownText.text = "3";
			countdownTime -= Time.deltaTime;
		}else if(countdownTime > 1){
			countdownText.text = "2";
			countdownTime -= Time.deltaTime;
		}else if(countdownTime > 0){
			countdownText.text = "1";
			countdownTime -= Time.deltaTime;
		}else if(countdownTime <= 0){
			Application.LoadLevel("Main");
		}

	}
}
