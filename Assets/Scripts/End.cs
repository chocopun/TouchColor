﻿using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("GoToResult");
	}

	// Update is called once per frame
	void Update () {

	}

	private IEnumerator GoToResult(){
		yield return new WaitForSeconds(1.0f);
		Application.LoadLevel("Result");
	}
}
