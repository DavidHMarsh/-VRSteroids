using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DebugPressFToFade : MonoBehaviour {

    public Animator targetAnimator;
    public Text targetText;
    public string animationName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Trying to fade");
            targetAnimator.Play(animationName, -1, 0f);
            
        }
	}
}
