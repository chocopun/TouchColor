using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Result : MonoBehaviour {
	private int score;
	private int correctNum;
	private int accurate;
	public Text scorePointText, correctPointText, accuratePointText;
	public Button registButton;
	public bool download = false;

	void Awake() {
		score = PlayerPrefs.GetInt("lastScore");
		correctNum = PlayerPrefs.GetInt("lastCorrectNum");
		accurate = PlayerPrefs.GetInt("lastAccurate");
		Debug.Log(score +","+ correctNum +","+ accurate);

		scorePointText = GameObject.Find("ScorePointText").GetComponent<Text>();
		correctPointText = GameObject.Find("CorrectPointText").GetComponent<Text>();
		accuratePointText = GameObject.Find("AccuratePointText").GetComponent<Text>();

		registButton = GameObject.Find("RegistButton").GetComponent<Button>();
		registButton.gameObject.SetActive(false);
	}

	void Start () {
		scorePointText.text = score.ToString() + " 点";
		correctPointText.text = correctNum.ToString() + " こ";
		accuratePointText.text = accurate.ToString() + " %";
	}

	void Update () {
	}

	public void RetryGame() {
		Application.LoadLevel("Main");
	}

	public void RankingButton() {
		GameObject.Find("InsertDBObject").GetComponent<InsertDB>().Insert();
	}

	public void Tweet() {
		Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("スコア:" + score.ToString() + "点 正答数:"+ correctNum.ToString() + "こ 正答率:" + accurate.ToString() + "% だったよ！#TouchColor"));
	}

	public void RegistButton() {
		if(download)
			registButton.gameObject.SetActive(false);
	}

	void OnDestroy(){
		PlayerPrefs.SetString("lastScene", "Result");
	}
}
