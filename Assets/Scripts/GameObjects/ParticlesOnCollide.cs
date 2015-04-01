using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class ParticlesOnCollide : MonoBehaviour {

    public GameObject particlePrefab;

    void OnCollisionEnter(Collision _col)
    {
        //Debug.Log("Hit");
        GameObject particle = Instantiate(particlePrefab, _col.contacts[0].point, Quaternion.LookRotation( _col.contacts[0].normal * -1)) as GameObject;
        Destroy(particle, 1);
    }

    public void Start()
    {
        //Debug.Log ("Starting");
    }

}

