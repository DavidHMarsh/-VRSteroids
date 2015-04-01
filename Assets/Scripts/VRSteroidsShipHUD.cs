using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class VRSteroidsShipHUD : MonoBehaviour {

	// Score
	public Text scoreText;

	// Time 
	public Text timeText;

	private float startTime;



	// Squares?

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}

	private float timeAlive;
	private string minutes;
	private string seconds;

	// Update is called once per frame
	void Update () {
		timeAlive = Time.time - startTime;
		minutes = Mathf.Floor(timeAlive / 60).ToString("00");
		seconds = (timeAlive % 60).ToString("00");
		timeText.text = minutes + ":" + seconds;

		scoreText.text = PlayerProfileManager.currentPlayer.playerScore.ToString();
	}


	void OnDestroy()
	{
        if (PlayerProfileManager.currentPlayer != null)
        {
            PlayerProfileManager.currentPlayer.timeSurvived = startTime - Time.time;
        }
	}

}