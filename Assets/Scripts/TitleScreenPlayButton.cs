using UnityEngine;
using System.Collections;

public class TitleScreenPlayButton : SceneTransitionButton {

    public void Clicked()
    {
        PlayerProfileManager.Instance.CreateNewCurrentPlayer();
        Application.LoadLevel(targetSceneName);
    }



}
