using UnityEngine;
using System.Collections;

public class DebugPuppetMaster : MonoBehaviour, IShipControl {

	public Transform TPuppet;
    public float Sensitivity = 1.0f;

    public void ShipControlActive(bool _active)
    {
        enabled = _active;
    }
    public GameObject playerShip { get { return gameObject;} }

	// Update is called once per frame
	void Update () {
		// controls
		// pitch
		float fPitchInput = Input.GetAxis("Vertical");
        TPuppet.Rotate(90 * Sensitivity * fPitchInput * Time.deltaTime, 0, 0);
		// heading
		float fHeadingInput = Input.GetAxis("Horizontal");
        TPuppet.Rotate(0, 90 * Sensitivity * fHeadingInput * Time.deltaTime, 0);
		//roll
		float fRollInput = Input.GetAxis("Roll");
        TPuppet.Rotate(0, 0, -90 * Sensitivity * fRollInput * Time.deltaTime);

		//TPuppet.rotation = transform.rotation;
		 ///
	}
}
