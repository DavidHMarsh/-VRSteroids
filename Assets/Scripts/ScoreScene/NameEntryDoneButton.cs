using UnityEngine;
using System.Collections;

public class NameEntryDoneButton : MonoBehaviour {

    public string targetSceneName;
    public StringBuilder stringBuilder;
	// Use this for initialization

	// Update is called once per frame
	public void Clicked()
    {
        PlayerProfileManager.currentPlayer.playerName = stringBuilder.builtString;
        PlayerProfileManager.Instance.SortPlayerIntoHighScores(PlayerProfileManager.currentPlayer);
        Application.LoadLevel(targetSceneName);
    }
}
