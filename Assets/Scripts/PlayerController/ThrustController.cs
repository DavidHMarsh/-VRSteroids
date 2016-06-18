using UnityEngine;
using System.Collections;

public class ThrustController : MonoBehaviour, IShipControl {

    public Transform ThrusterTransform;
	public float maximumSpeed = 100f;
	public float ForwardThrust = 20f;
    public float TurningThrust = .1f;

	public float DragCoefficient = .1f;

    #region IShipControl Methods and Properties
    public GameObject playerShip {get; set;}

    public void ShipControlActive(bool _active)
    {
        this.enabled = _active;
    }
    #endregion

    //public float timeLeft = 60;
	// Use this for initialization


	
	// Update is called once per frame
	void FixedUpdate () {
		//timeLeft -= Time.deltaTime;
		/*if (timeLeft <= 0) {
			Application.LoadLevel(2);
			return;
				}*/
		//oculusViewVector = oculusTransform.forward;
		Accelerate();
	}

	// oculusViewVector is the oculus angle relative to the screen
	// camera.transform.forward;

	void OnCollisionEnter(Collision hit)
	{
		
	}


	void Accelerate()
	{
        float fThrustInput = Input.GetAxis("Thrust");
        float fLiftInput = Input.GetAxis("Lift");
        float fStrafeInput = Input.GetAxis("Strafe");
        
        //Debug.Log(fThrustInput.ToString() + " " + fLiftInput.ToString() + " " + fStrafeInput.ToString());
        //Debug.Log(rigidbody.velocity.magnitude.ToString());

        //float fCurrentSpeed = this.rigidbody.velocity.magnitude;
        if (fThrustInput != 0 || fLiftInput != 0 || fStrafeInput != 0)
		{
            // Get the vector of thrust inputs along the local axes
            Vector3 desiredForce = ThrusterTransform.forward * fThrustInput;
            desiredForce = desiredForce + ThrusterTransform.up * fLiftInput;
            desiredForce = desiredForce + ThrusterTransform.right * fStrafeInput;
            // Clamp if it's too big
            if(desiredForce.magnitude > 1)
            {
                desiredForce = Vector3.Normalize(desiredForce);
            }

            desiredForce = desiredForce * ForwardThrust;

            // Turning component reduces lateral drift
            float fUpSpeed, fRightSpeed;
            fUpSpeed = Vector3.Dot(GetComponent<Rigidbody>().velocity, ThrusterTransform.up);
            fRightSpeed = Vector3.Dot(GetComponent<Rigidbody>().velocity, ThrusterTransform.right);

            desiredForce = desiredForce - TurningThrust * fUpSpeed * ThrusterTransform.up;
            desiredForce = desiredForce - TurningThrust * fRightSpeed * ThrusterTransform.right;
            

            GetComponent<Rigidbody>().AddForce(desiredForce);
			
   
            
        }
        else
        {
            // Decelerate
            GetComponent<Rigidbody>().AddForce(-1 * GetComponent<Rigidbody>().velocity * DragCoefficient , ForceMode.Acceleration);
        }

        // Clamp velocity
        if (this.GetComponent<Rigidbody>().velocity.magnitude > maximumSpeed)
        {
            float fOverSpeedRatio = this.GetComponent<Rigidbody>().velocity.magnitude / maximumSpeed;
            this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity / fOverSpeedRatio;

        }
	}
}
