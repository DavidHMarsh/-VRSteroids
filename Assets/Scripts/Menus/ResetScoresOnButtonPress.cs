using UnityEngine;
using System.Collections;

public class ResetScoresOnButtonPress : MonoBehaviour {
    public void Clicked()
    {
        PlayerProfileManager.Instance.EraseProfiles();
        ScoresSceneManager.Instance.DisplayScores();
    }

}
