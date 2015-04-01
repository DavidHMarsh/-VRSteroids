using UnityEngine;
using System.Collections;

public class LevelWave : MonoBehaviour {

    public GameObject asteroidPrefab;
    public Vector3 originPoint = Vector3.zero;
    public float radius = 500;
    public float safeRadius = 50;
    public int numberOfDebris = 4;
    public int initialSpeed = 10;

    private int iAsteroidCount = 0;

    public int AsteroidDestroyed(GameObject asteroid)
    {
        iAsteroidCount--;
        return iAsteroidCount;
    }

    public int AsteroidCreated(GameObject asteroid)
    {
        iAsteroidCount++;
        return iAsteroidCount;
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfDebris; i++)
        {

            // minimum 10m radius around the player for initial spawns.
            Vector3 vSpawn = (radius - safeRadius) * Random.insideUnitSphere + originPoint;
            vSpawn = vSpawn + safeRadius * (vSpawn-originPoint).normalized;

            GameObject newDebris = Instantiate(asteroidPrefab, vSpawn, Random.rotation) as GameObject;
            if (newDebris.renderer != null && newDebris.renderer.material != null)
            {
                newDebris.renderer.material.color = new Color(Random.value, Random.value, Random.value);
            }

            newDebris.rigidbody.velocity = Random.onUnitSphere * initialSpeed;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

