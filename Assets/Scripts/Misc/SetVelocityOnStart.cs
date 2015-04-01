using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class SetVelocityOnStart : MonoBehaviour {
    public Vector3 startingVelocity;
	// Use this for initialization
	void Start () {
        rigidbody.velocity = startingVelocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
