using UnityEngine;
using System.Collections;

public class SceneTransitionButton : MonoBehaviour {

    public string targetSceneName;

	public void Clicked()
    {
        Application.LoadLevel(targetSceneName);
    }

    public void MethodWithParameter (int num)
    {

    }
}
