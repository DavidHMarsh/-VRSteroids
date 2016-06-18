using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	
	private bool bCursorUnlocked = false;
	// Use this for initialization
	void Start () {
			#if UNITY_STANDALONE_WIN
			Cursor.visible = false;
			#endif
	}
	
	// Update is called once per frame
	void Update () {


		// Toggle mouse when middle clicking
		#if UNITY_STANDALONE_WIN
		if(!bCursorUnlocked)
		{
			Screen.lockCursor = true;
		}
		#endif
		if (Input.GetMouseButtonDown (2)) 
		{
			bCursorUnlocked = !bCursorUnlocked;
			if(bCursorUnlocked)
			{
				Cursor.visible = true;
				Screen.lockCursor = false;
			}
			else
			{
				Cursor.visible = false;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "projectile") {

			GetComponent<AudioSource>().Play();
			Invoke("LoadLevel", 1.0f);
		}
	}

	void LoadLevel()
	{
		Application.LoadLevel(1);
	}
}
