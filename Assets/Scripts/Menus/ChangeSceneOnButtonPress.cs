using UnityEngine;
using System.Collections;

public class ChangeSceneOnButtonPress : MonoBehaviour {

    public string targetSceneName;
    public string buttonName;

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(buttonName)) 
        {
            Debug.Log("attempting change scene");
            Application.LoadLevel(targetSceneName);
        }
        else
        {
            //Debug.Log("Not button " + buttonName);
        }
    }
}
