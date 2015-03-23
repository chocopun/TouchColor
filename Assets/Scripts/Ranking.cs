using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

public class Ranking : MonoBehaviour {
	//public string url = "http://chnr.wc.lt";
	public string url = "chnr.wc.lt/output.php";
	Text highScoreText;
	Text Top1NameText, Top1ScoreText;
	Text Top2NameText, Top2ScoreText;
	Text Top3NameText, Top3ScoreText;
	Text Top4NameText, Top4ScoreText;
	Text Top5NameText, Top5ScoreText;

	private string name;
	private string score;
	private string lastScene;

	void Awake() {
		Top1NameText = GameObject.Find("Top1NameText").GetComponent<Text>();
		Top2NameText = GameObject.Find("Top2NameText").GetComponent<Text>();
		Top3NameText = GameObject.Find("Top3NameText").GetComponent<Text>();
		Top4NameText = GameObject.Find("Top4NameText").GetComponent<Text>();
		Top5NameText = GameObject.Find("Top5NameText").GetComponent<Text>();
		Top1ScoreText = GameObject.Find("Top1ScoreText").GetComponent<Text>();
		Top2ScoreText = GameObject.Find("Top2ScoreText").GetComponent<Text>();
		Top3ScoreText = GameObject.Find("Top3ScoreText").GetComponent<Text>();
		Top4ScoreText = GameObject.Find("Top4ScoreText").GetComponent<Text>();
		Top5ScoreText = GameObject.Find("Top5ScoreText").GetComponent<Text>();
		highScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
		highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();

		lastScene = PlayerPrefs.GetString("lastScene");
	}

	void Start () {
		StartCoroutine("GetUserData");
	}

	void Update () {

	}

	private IEnumerator GetUserData(){
		//MySQLのユーザーを管理するテーブルデータを取得しにいく
		WWW gettext = new WWW(url);

		// レスポンスを待つ
		yield return gettext;
		Debug.Log( gettext.text );

		//JSON形式で全てのユーザーデータを取得
		JsonData jsonParser = JsonMapper.ToObject(gettext.text);
		string[] data = new string[jsonParser.Count];

		//すべてのユーザーの名前と一致を調べて一致したユーザーデータを取り出す
		for(int i=0; i<jsonParser.Count; i++){
			name += jsonParser[i]["name"];
			score += jsonParser[i]["score"];
		}

		Top1NameText.text = jsonParser[0]["name"].ToString();
		Top2NameText.text = jsonParser[1]["name"].ToString();
		Top3NameText.text = jsonParser[2]["name"].ToString();
		Top4NameText.text = jsonParser[3]["name"].ToString();
		Top5NameText.text = jsonParser[4]["name"].ToString();

		Top1ScoreText.text = jsonParser[0]["score"].ToString();
		Top2ScoreText.text = jsonParser[1]["score"].ToString();
		Top3ScoreText.text = jsonParser[2]["score"].ToString();
		Top4ScoreText.text = jsonParser[3]["score"].ToString();
		Top5ScoreText.text = jsonParser[4]["score"].ToString();
	}
}
