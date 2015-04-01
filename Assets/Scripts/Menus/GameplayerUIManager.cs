using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameplayerUIManager : MonoBehaviour {

    public Text scoreValue;
    public Text timeText;
	// Update is called once per frame
	void Update () {
        //scoreValue.text = Time.time.ToString();
        float gameLifetime = Time.time - PlayerProfileManager.currentPlayer.timeGameStarted;

        string minSec = string.Format("{0}:{1:00}", (int)gameLifetime / 60, (int)gameLifetime % 60);

        timeText.text = minSec;
        scoreValue.text = PlayerProfileManager.currentPlayer.playerScore.ToString();
	}
}
