using UnityEngine;
using System.Collections;

public class SetParticleColorEachFrame : MonoBehaviour {

    /// <summary>
    /// Unity is dumb, and does not let you hook up mecanim animator to the spawn color of particles.
    /// Therefore, it is necessary to have mecanim animate a value on a script, and have that script set the start color of the particles.
    /// </summary>


   
    // This value is animated by mecanim.
    public Color animatedColor = Color.white;


	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        particleSystem.startColor = animatedColor;
	}
}
