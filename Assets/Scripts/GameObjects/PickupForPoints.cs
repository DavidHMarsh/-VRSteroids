using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody))]

public class PickupForPoints : MonoBehaviour {

    public int points = 1000;

    public bool destroyAfterGrantingPoints = true;

    // This boolean exists because objects are not destroyed until the end of the frame, and multiple collisions could occur before that happens.
    private bool pointsGranted = false;

	// Use this for initialization

    void OnTriggerEnter(Collider _col)
    {
        // Hard coding string tags is bag but it's better than manually assigning.
        if (_col.tag == "player")
        {
            ShipUIManager uiManager = _col.gameObject.GetComponentInChildren<ShipUIManager>();
            if(uiManager != null)
            {
                uiManager.DisplayAlertText("+" + points.ToString(), Color.green);
            }

            if (!pointsGranted && PlayerProfileManager.currentPlayer != null)
            {
                PlayerProfileManager.currentPlayer.playerScore += points;
            }
            if (PlayerProfileManager.currentPlayer == null)
            {
                Debug.Log("there is no current player");
            }
            if (destroyAfterGrantingPoints)
            {
                Destroy(transform.root.gameObject);

            }
        }
    }

}
