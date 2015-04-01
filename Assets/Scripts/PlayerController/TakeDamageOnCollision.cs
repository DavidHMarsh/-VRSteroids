using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class TakeDamageOnCollision : MonoBehaviour {

    public HealthComponent health;
    public int damagerPerHit;
    public string desiredTag;

	// Use this for initialization
	void Start () {
        health = GetComponentInParent<HealthComponent>();
        if (health == null)
        {
            Debug.LogError("Error!  Not healthcomponent found in hierarchy", this);
            return;
        }
        
	}

    void OnCollisionEnter(Collision _hit)
    {
        
        if (_hit.collider.tag == desiredTag)
        {
            health.DamageHealth(damagerPerHit);
        }
    }
	
	// Update is called once per frame

}
