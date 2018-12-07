﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelMenu : MonoBehaviour {

	public GameObject completeLevelUI;
	
	// Update is called once per frame

	void Awake() {
		if(completeLevelUI == null){
			Debug.LogError("Need CompleteLevelMenu");
		}
        completeLevelUI.SetActive(false);
        //Resume();
	}

	void Start() {

	}

	void Update() {

	}

	public void Continue(){
		if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void loadMenu(){
		SceneManager.LoadScene("Menu");
	}

	public void quitGame(){
		Debug.Log("QUITGAME");
		Application.Quit();
	}

}