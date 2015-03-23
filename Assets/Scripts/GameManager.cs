using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Text timerText;
	public float time = 15.0f;
	public Text comboText;

	public int correctNum = 0;
	public int inCorrectNum = 0;
	private int denom; //分子, 分母
	private int accurate; //正答率
	public int combo = 0;
	public int score = 0;
	private int point = 10;

	public AudioClip collectSound;
	public AudioClip inCollectSound;

	void Awake() {
		comboText.gameObject.SetActive(false);
	}

	void Start () {
		AudioSource[] audioSources = GetComponents<AudioSource>();
	}

	void Update () {
		if(time > 0){
			time -= Time.deltaTime;
		}else{
			time = 0;
				EndGame();
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
		comboText.gameObject.SetActive(false);
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

	void EndGame(){
		Debug.Log("EndGame");
		CalcAccurate();
		PlayerPrefs.SetInt("lastScore", score);
		PlayerPrefs.SetInt("lastCorrectNum", correctNum);
		PlayerPrefs.SetInt("lastAccurate", accurate);
		if(PlayerPrefs.GetInt("highScore") < score)
			PlayerPrefs.SetInt("highScore", score);
		Application.LoadLevel("End");
	}
}
