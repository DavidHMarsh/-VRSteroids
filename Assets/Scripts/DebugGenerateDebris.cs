using UnityEngine;
using System.Collections;

public class DebugGenerateDebris : MonoBehaviour {
	public GameObject debrisPrefab;
	public Vector3 originPoint = Vector3.zero;
	public float radius = 1000;
    public float safeRadius = 20;
	public int numberOfDebris = 10;
    public int initialSpeed = 20;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < numberOfDebris; i ++)
        {
            
            // minimum 10m radius around the player for initial spawns.
            Vector3 vSpawn = (radius - safeRadius) * Random.insideUnitSphere + safeRadius * Random.onUnitSphere + originPoint;
			
            GameObject newDebris = Instantiate(debrisPrefab, vSpawn, Random.rotation) as GameObject;
            if (newDebris.renderer != null && newDebris.renderer.material != null)
            {
                newDebris.renderer.material.color = new Color(Random.value, Random.value, Random.value);
            }

            newDebris.rigidbody.velocity = Random.onUnitSphere * initialSpeed;

        }
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
