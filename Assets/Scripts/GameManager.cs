using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Text timerText;
	public float time = 15.0f;
	public GameObject gameContents;
	public GameObject resultContents;
	public Text countdownText;
	private float countdownTime = 3.0f;
	public Text comboText;

	public int correctNum = 0;
	public int inCorrectNum = 0;
	private int denom; //分子, 分母
	private int accurate; //正答率
	public Text scorePointText, correctPointText, accuratePointText;
	public int combo = 0;
	public int score = 0;
	private int point = 10;
	private bool gameStart = false;

	public AudioClip collectSound;
	public AudioClip inCollectSound;

	void Awake() {
		gameContents.SetActive(false);
		resultContents.SetActive(false);
		comboText.gameObject.SetActive(false);
	}

	void Start () {
		AudioSource[] audioSources = GetComponents<AudioSource>();
	}

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
			GameStart();
		}

		if(gameStart){
			if(time > 0){
				time -= Time.deltaTime;
			}else{
				time = 0;
				EndGame();
			}
		}
		timerText.text = time.ToString("f1");
		comboText.text = combo.ToString() + " コンボ";
	}

	public void Collect() {
		correctNum++;
		combo++;
		score += point * combo;
		comboText.gameObject.SetActive(true);
		GetComponent<AudioSource>().PlayOneShot(collectSound);
	}

	public void InCollect() {
		inCorrectNum++;
		combo = 0;
		comboText.gameObject.SetActive (false);
		GetComponent<AudioSource>().PlayOneShot(inCollectSound);
	}

	int CalcAccurate() {
		if(correctNum!=0){
			denom = correctNum + inCorrectNum;
			accurate = (correctNum*100)/denom;
			//return accurate;
		}else{
			accurate = 0;
			//return 0;
		}
		return accurate;
	}

	void GameStart() {
		countdownText.gameObject.SetActive(false);
		gameContents.SetActive(true);
		gameStart = true;
	}

	void EndGame(){
		gameContents.SetActive(false);
		resultContents.SetActive(true);
		CalcAccurate();
		scorePointText.text = score.ToString() + " 点";
		correctPointText.text = correctNum.ToString() + " こ";
		accuratePointText.text = accurate.ToString() + " %";
	}

	public void RetryGame() {
		Application.LoadLevel("Main");
	}

	public void Tweet() {
		Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("スコア:" + score.ToString() + "点 正答数:"+ correctNum.ToString() + "こ 正答率:" + accurate.ToString() + "% だったよ！#TouchColor"));
	}
}
