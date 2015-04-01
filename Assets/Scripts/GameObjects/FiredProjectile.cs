using UnityEngine;
using System.Collections;

public class FiredProjectile : MonoBehaviour
{

    public bool bUsingFocalPoint = false;
    public Vector3 aimFocalPoint;
    public Quaternion aimFocalOrientation;
    public bool shootThrough = false;
    public float shotSpeed;
    
    public float fExpirationTime = 2;

    [HideInInspector]
    public GameObject projectileParent;
    private float fFocusTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        // decay timer
        fExpirationTime += Time.time;

        // Aim focal point is used to direct shots from off-camera to line up with the player's reticle
        if (bUsingFocalPoint)
        {
            Vector3 vFocusOffset = aimFocalPoint - transform.position;
            float fFocusDistance = Vector3.Magnitude(vFocusOffset);

            // Get moving towards the focal target
            GetComponent<Rigidbody>().velocity += vFocusOffset * shotSpeed / fFocusDistance;


            // And start the timer to reach it
            fFocusTime = Time.time + fFocusDistance / shotSpeed;


        }
        else
        {
            GetComponent<Rigidbody>().velocity += transform.forward * shotSpeed;
        }

        transform.RotateAround(transform.forward, Random.Range(0, 360));
    }

    void OnCollisionEnter(Collision other)
    {
        if (!shootThrough) Destroy(this.gameObject);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // Check the expiration time
        if (fExpirationTime < Time.time) Destroy(this.gameObject);

        // If traveling to a focus target, see if it was reached
        if (fFocusTime != 0.0f && fFocusTime < Time.time)
        {
            // The bullet has reached its focal point. Turning now.
            fFocusTime = 0.0f;
            transform.position = aimFocalPoint;
            transform.rotation = aimFocalOrientation;
            GetComponent<Rigidbody>().velocity = transform.forward * GetComponent<Rigidbody>().velocity.magnitude;
        }
    }

    
}
