using UnityEngine;
using System.Collections;

public class HeadTurnControls : MonoBehaviour {

	// Turn Speed Multiplier
	public float fTurnSpeed = 1f; //30f;
	// Dead zone for turning (like dead zone on a joystick)
	public float fRotationDeadZone = 30.0f;  //.7f;
	// Max rotation angle
	public float fRotationMax = 90.0f;  //1f;

	public Transform T_Follower;
	public Transform T_Leader;

	// Use this for initialization



	// Update is called once per frame
	void Update () {
		
		AdjustView();

	}

	void AdjustView()
	{
		// Line up the cameraTransform with the Oculus transform?
		/*T_Follower.rotation = transform.rotation * T_Leader.rotation; // spins the camera wildly.

		Vector3 diffBetweenViewVectorAndForward = (T_Follower.forward - transform.forward);
		
		float magnitudeDiffBetweenViewVectorAndForward = (T_Follower.forward - Vector3.forward).magnitude;
		if (diffBetweenViewVectorAndForward.magnitude > fRotationDeadZone)
		{
			float headTurnMagnitude = diffBetweenViewVectorAndForward.magnitude - fRotationDeadZone;
			float minAndMaxDifference = fRotationMax - fRotationDeadZone;
			// fRotationDelta is measured in degrees
			float fRotationDelta = fTurnSpeed * Time.deltaTime;
			fRotationDelta *= Mathf.Clamp01(Mathf.Pow(headTurnMagnitude / minAndMaxDifference, 2)); 


			//Debug.Log(Mathf.Clamp01(headTurnMagnitude / minAndMaxDifference).ToString());
			transform.rotation = Quaternion.RotateTowards(transform.rotation, T_Follower.rotation, fRotationDelta);
			// goes from zero to 1 

			transform.forward += fTurnSpeed * Time.deltaTime * diffBetweenViewVectorAndForward;
			T_Follower.forward = transform.forward + T_Leader.forward;
		}*/

		// OffsetAngle is the amount by which the camera should turn.
		// Start by taking the angle between Follower and Leader
		float fOffsetAngle = Quaternion.Angle(T_Follower.rotation, T_Leader.rotation);
	   
		if (fOffsetAngle > fRotationDeadZone)
		{
			// Then clamp it to fRotationMax
			fOffsetAngle = Mathf.Clamp(fOffsetAngle, fRotationDeadZone, fRotationMax);
			
            //Debug.Log(fOffsetAngle.ToString());
			
            // Then subtract the Dead Zone angle so it starts at 0
			fOffsetAngle -= fRotationDeadZone;
			// Then scale it down by the turn speed multiplier
			fOffsetAngle *= fTurnSpeed*Time.deltaTime;

			

			// Then rotate by that amount
			//T_Leader.rotation = Quaternion.RotateTowards(T_Follower.rotation, T_Leader.rotation, -fOffsetAngle);
			T_Follower.rotation = Quaternion.RotateTowards(T_Follower.rotation, T_Leader.rotation, fOffsetAngle);
            //T_Follower.Rotate(transform.up, fOffsetAngle);

		}


	}

}
