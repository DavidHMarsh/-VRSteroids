using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoresSceneManager : MonoBehaviour {

    public static ScoresSceneManager Instance;

    public Canvas baseCanvas;
    public ScoreListing scorePrefab;
    public RectTransform scoreboardStartAnchor;
    public int maximumScoresToDisplay = 10;

    public ScoreListing[] scoreListingArray;

    void Awake()
    {
        if (ScoresSceneManager.Instance != null)
        {
            Destroy(ScoresSceneManager.Instance);
        }
        ScoresSceneManager.Instance = this;
    }

	// Use this for initialization
	void Start () {
        DisplayScores();
	}
	
    [ContextMenu("Display Scores")]
    public void DisplayScores()
    {
        Debug.Log("Displaying scores");
        #region Destroy existing scores

        if (scoreListingArray != null)
        {
            foreach (ScoreListing _listing in scoreListingArray)
            {
                if (_listing == null) continue;
                else
                {
                    DestroyImmediate(_listing.gameObject);
                }
            }
        }

        #endregion

        int _counter = 0;

        VRSteroidsPlayerProfile _blankProfile = new VRSteroidsPlayerProfile();
        _blankProfile.playerName = "----------";
        _blankProfile.timeSurvived = -1;

        scoreListingArray = new ScoreListing[maximumScoresToDisplay];



	    foreach(VRSteroidsPlayerProfile _profile in PlayerProfileManager.Instance.profiles)
        {

            ScoreListing _newScore = (Instantiate(scorePrefab.gameObject, Vector3.zero, Quaternion.identity)as GameObject).GetComponent<ScoreListing>();
            if (_newScore == null) Debug.LogError("Score is null");
            _newScore.transform.parent = baseCanvas.transform;

            _newScore.listNumber = _counter + 1;


            if (_profile == null)
            {
                _newScore.Profile = _blankProfile;
            }
            else
            {
                _newScore.Profile = _profile;
            }

            _newScore.transform.localScale = Vector3.one;

            float _verticalOffset = (_counter  * (_newScore.textIndex.rectTransform.rect.height * _newScore.textIndex.rectTransform.localScale.y));

            _newScore.transform.localPosition = scoreboardStartAnchor.localPosition + Vector3.down * _verticalOffset;

            scoreListingArray[_counter] = _newScore;

            _counter += 1;

            if (_counter >= maximumScoresToDisplay)
                break;
        }
	
    }

}
