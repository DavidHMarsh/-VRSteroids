using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreListing : MonoBehaviour {
    [SerializeField]

    private VRSteroidsPlayerProfile profile;

    public int listNumber = -1;
    public float heightspacing = 10f;
    public Text textIndex;
    public Text textName;
    public Text textScore;
    public Text textTimeSurvived;
    public Text textWaves;

    public Vector3 originalPosition;


    public VRSteroidsPlayerProfile Profile { 
        get { return profile; } 
        set
        {
            profile = value;
            RefreshText();
        }
    }

	// Use this for initialization
	void Start () {
        if (profile != null) RefreshText();
        originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = originalPosition + Vector3.right * 0  * Mathf.Sin(Time.time * 0.5f + listNumber *  1 * Mathf.PI / 15) + 
            Vector3.forward * 0.5f *  Mathf.Sin(Time.time * 0.5f + listNumber *  4 * Mathf.PI / 15);
	}

    public void RefreshText()
    {
        textName.text = profile.playerName;

        textScore.text = profile.playerScore.ToString();

        if (profile.timeSurvived >= 0)
        {
            string minSec = string.Format("{0}:{1:00}", (int)profile.timeSurvived / 60, (int)profile.timeSurvived % 60);
            textTimeSurvived.text = minSec;
        }
        else
            textTimeSurvived.text = "--:--";

        textWaves.text = profile.wavesSurvived.ToString();

        textIndex.text = listNumber.ToString() + ". ";
    }
}
