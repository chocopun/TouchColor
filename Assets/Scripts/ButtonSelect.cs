using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonSelect : MonoBehaviour {
	public Image topImage;
	public Button Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9;
	private Color pressedColor;
	private int buttonNumber = 9;
	private Button collectButton;
	GameObject gameManager;

	void Awake() {
		Next();
	}

	void Start () {
		gameManager = GameObject.Find("GameManager");
	}

	void Update () {

	}

	void SetRandomColorToImage() {
		topImage.color = new Color(Random.value,Random.value,Random.value);
	}

	Button GetRandomButton() {
		Button returnButton = null;
		switch(Random.Range(1, buttonNumber+1)){
			case 1:
			returnButton = Button1;
			break;
			case 2:
			returnButton = Button2;
			break;
			case 3:
			returnButton = Button3;
			break;
			case 4:
			returnButton = Button4;
			break;
			case 5:
			returnButton = Button5;
			break;
			case 6:
			returnButton = Button6;
			break;
			case 7:
			returnButton = Button7;
			break;
			case 8:
			returnButton = Button8;
			break;
			case 9:
			returnButton = Button9;
			break;
			default:
			Debug.Log("invalid button number");
			break;
		}
		return returnButton;
	}

	void SetImageColorToButton(Button button) {
		button.image.color = topImage.color;
	}

	void SetRandomColors() {
		Button1.image.color = new Color(Random.value, Random.value, Random.value);
		Button2.image.color = new Color(Random.value, Random.value, Random.value);
		Button3.image.color = new Color(Random.value, Random.value, Random.value);
		Button4.image.color = new Color(Random.value, Random.value, Random.value);
		Button5.image.color = new Color(Random.value, Random.value, Random.value);
		Button6.image.color = new Color(Random.value, Random.value, Random.value);
		Button7.image.color = new Color(Random.value, Random.value, Random.value);
		Button8.image.color = new Color(Random.value, Random.value, Random.value);
		Button9.image.color = new Color(Random.value, Random.value, Random.value);
	}

	public void PressButton1 () {
		if(topImage.color == Button1.image.color){
			Collect();
		}else{
			InCollect();
		}
	}
	public void PressButton2 () {
		if(topImage.color == Button2.image.color){
			Collect();
		}else{
			InCollect();
		}
	}
	public void PressButton3 () {
		if(topImage.color == Button3.image.color){
			Collect();
		}else{
			InCollect();
		}
	}
	public void PressButton4 () {
		if(topImage.color == Button4.image.color){
			Collect();
		}else{
			InCollect();
		}
	}
	public void PressButton5 () {
		if(topImage.color == Button5.image.color){
			Collect();
		}else{
			InCollect();
		}
	}
	public void PressButton6 () {
		if(topImage.color == Button6.image.color){
			Collect();
		}else{
			InCollect();
		}
	}
	public void PressButton7 () {
		if(topImage.color == Button7.image.color){
			Collect();
		}else{
			InCollect();
		}
	}
	public void PressButton8 () {
		if(topImage.color == Button8.image.color){
			Collect();
		}else{
			InCollect();
		}
	}
	public void PressButton9 () {
		if(topImage.color == Button9.image.color){
			Collect();
		}else{
			InCollect();
		}
	}

	void Next() {
		SetRandomColorToImage();
		SetRandomColors();
		collectButton = GetRandomButton();
		SetImageColorToButton(collectButton);
	}

	void Collect() {
		Next();
		gameManager.SendMessage ("Collect");
	}

	void InCollect() {
		gameManager.SendMessage ("InCollect");
	}
}
