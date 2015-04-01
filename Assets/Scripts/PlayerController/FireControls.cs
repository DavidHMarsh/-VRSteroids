using UnityEngine;
using System.Collections;

public class FireControls : MonoBehaviour, IShipControl
{

    public GameObject shotPrefab;
    public Transform shotOrigin;
    public Transform shotAimPoint;
    private float shotSpeed = 1200;
    public bool addParentVelocity = false;

    private float fCooldown = 0.1f;

    private GameObject shotInstance;
    private bool bQueued;
    private float fCooldownExpires;

    #region IShipControl Methods and Properties
    public GameObject playerShip { get; set; }

    public void ShipControlActive(bool _active)
    {
        this.enabled = _active;
    }
    #endregion
    // Use this for initialization
    void Start()
    {
        fCooldownExpires = Time.time;

        if (shotOrigin == null)
        {
            shotOrigin = transform;
        }
    }

    void Shoot(GameObject shot, Vector3 offset)
    {
        Vector3 vOrigin = shotOrigin.position + offset;

        shotInstance = Instantiate(shot, vOrigin, shotOrigin.rotation) as GameObject;

        if (addParentVelocity && shotInstance.GetComponent<Rigidbody>() != null && shotOrigin.root.gameObject.GetComponent<Rigidbody>() != null)
        {
            shotInstance.GetComponent<Rigidbody>().velocity = shotOrigin.root.gameObject.GetComponent<Rigidbody>().velocity;
        }

        FiredProjectile firedProjectile = shotInstance.GetComponent<FiredProjectile>();
        if (firedProjectile != null)
        {
            firedProjectile.shotSpeed = shotSpeed;
            firedProjectile.projectileParent = transform.root.gameObject;

            if (shotAimPoint != null)
            {
                firedProjectile.bUsingFocalPoint = true;
                firedProjectile.aimFocalPoint = shotAimPoint.position + offset;
                firedProjectile.aimFocalOrientation = shotAimPoint.rotation;
            }
        }

        fCooldownExpires = Time.time + fCooldown;
    }

    // Update is called once per frame 
    void Update()
    {

        if (Time.time > fCooldownExpires)
        {
            if (bQueued) Shoot(shotPrefab, Vector3.zero);

            else if (Input.GetButtonDown("Fire"))
            {
                Shoot(shotPrefab, Vector3.zero);

            }
        }

    }
}
