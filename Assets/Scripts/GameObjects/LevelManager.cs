using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public LevelWave[] WAVES;
    private LevelWave Wave_Current;

    private static LevelManager manager;
    public static LevelManager Manager { get { return manager; } }

    private int iNextWave = 0;
    private static LevelWave currentWave;
    public static LevelWave CurrentWave { get { return currentWave; } }

    public void AsteroidDestroyed(GameObject asteroid)
    {
        if (currentWave != null)
        {
            // Decrement the asteroid count and check the result
            if( currentWave.AsteroidDestroyed(asteroid) == 0)
            {
                Debug.Log("Final Asteroid Destroyed!");
                Destroy(currentWave.gameObject);
                iNextWave++;
                StartWave(iNextWave);
            }
        }
    }

    public void AsteroidCreated(GameObject asteroid)
    {
        if (currentWave != null)
        {
            currentWave.AsteroidCreated(asteroid);
        }
    }

    void StartWave(int waveIndex)
    {
        if(WAVES[waveIndex] != null)
        {
            Debug.Log("SPAWNING WAVE " + waveIndex.ToString());
            GameObject newWaveObject = Instantiate(WAVES[waveIndex].gameObject) as GameObject;
            
            currentWave = newWaveObject.GetComponent<LevelWave>();
        }
        else
        {
            Application.LoadLevel("NameEntryScene");
        }
    }

	// Use this for initialization
	void Start () {
	
        if(manager != null)
        {
            Destroy(manager);
        }
        manager = this;

        StartWave(iNextWave);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
