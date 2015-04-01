using UnityEngine;
using System.Collections;

public class InitializeNewPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerProfileManager.Instance.CreateNewCurrentPlayer();
        PlayerProfileManager.currentPlayer.timeGameStarted = Time.time;
	}

    void OnDestroy()
    {

    }
	
}
