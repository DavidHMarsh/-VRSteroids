using UnityEngine;
using System.Collections;

public class AsteroidObject : MonoBehaviour {

    public int scoreValue = 0;
    public GameObject explosion;
    public float fragmentSpeed = 20.0f;
    public float fragmentRadius = 25.0f;
    public GameObject[] FRAGMENT_ASTEROIDS;

    // Use this for initialization
    void Awake()
    {
        // Increment the asteroid wave counter
        if (LevelManager.Manager != null)
        {
            LevelManager.Manager.AsteroidCreated(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "projectile")
        {

            // Award points
            if (PlayerProfileManager.currentPlayer != null)
            {
                PlayerProfileManager.currentPlayer.playerScore += scoreValue;


                FiredProjectile firedProjectile = other.gameObject.GetComponentInChildren<FiredProjectile>();
                if (firedProjectile != null)
                {
                    GameObject playerShip = firedProjectile.projectileParent;
                    if(playerShip != null)
                    {
                        ShipUIManager uiManager = playerShip.GetComponentInChildren<ShipUIManager>();
                        if (uiManager != null)
                        {
                            uiManager.DisplayAlertText("+" + scoreValue.ToString(), Color.green);
                        }
                    }
                }

            }

            // Explode
            if (explosion != null)
            {
                GameObject G_Explosion = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
                Destroy(G_Explosion, 5.0f);
            }
            
            // Play sound
            if (audio != null)
            {
                audio.Play();
                //AudioSource.PlayClipAtPoint(clip, position);
            }

            // Spawn asteroid fragments
            if(FRAGMENT_ASTEROIDS != null )
            {
                // instance of a new asteroid
                GameObject gFragmentAsteroid;
                // Where to spawn relative to the parent asteroid
                Vector3 vOffset = fragmentRadius * other.gameObject.transform.up;
                
                int i;
                for (i = 0; i < FRAGMENT_ASTEROIDS.Length; i++ )
                {
                    // vOffset is up/down/right/left of the projectile impact
                    switch ( i % 4 )
                    {
                        case 0:
                            vOffset = other.gameObject.transform.up;
                            break;
                        case 1:
                            vOffset = -1 * other.gameObject.transform.up;
                            break;
                        case 2:
                            vOffset = other.gameObject.transform.right;
                            break;
                        case 3:
                            vOffset = -1 * other.gameObject.transform.right;
                            break;
                    }
                    // If more than 4 fragments, spawn the later ones further away
                    Vector3 vSpawnLocation = transform.position + (1 + i / 4) * fragmentRadius * vOffset;
                   
                    gFragmentAsteroid = Instantiate(FRAGMENT_ASTEROIDS[i], vSpawnLocation, transform.rotation) as GameObject;

                    gFragmentAsteroid.rigidbody.velocity = fragmentSpeed * vOffset + rigidbody.velocity;
                    gFragmentAsteroid.rigidbody.angularVelocity = 4 * Random.onUnitSphere;
                }
            }

            // Decrement the asteroid wave counter
            if (LevelManager.Manager != null)
            {
                LevelManager.Manager.AsteroidDestroyed(this.gameObject);
            }

            //Destroy(other.gameObject);
            Destroy(this.gameObject);

        }
        /*else if (other.gameObject.tag == "player")
        {
            // Does not work on Gear VR
            Debug.Log("Vibrate!!!!");
            Handheld.Vibrate();
        }*/

    }
    

}
