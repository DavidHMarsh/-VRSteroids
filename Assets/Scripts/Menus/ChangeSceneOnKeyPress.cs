using UnityEngine;
using System.Collections;

public class ChangeSceneOnKeyPress : MonoBehaviour {

    public string targetSceneName;
    public KeyCode key;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(key))
        {
            Application.LoadLevel(targetSceneName);
        }
	}
}
