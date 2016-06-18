using UnityEngine;
using System.Collections;

public class FadeOutAndVanish : MonoBehaviour {

    public float duration = 5.0f;

    private float expireTime;
    private Material materialFading;
    private float startAlpha;

	// Use this for initialization
	void Start ()
    {
        expireTime = Time.time + duration;

        if (gameObject.GetComponent<Renderer>() != null && gameObject.GetComponent<Renderer>().material != null)
        {
            materialFading = gameObject.GetComponent<Renderer>().material;
            startAlpha = materialFading.color.a;
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.GetComponent<Renderer>().material != null)
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            float newAlpha = startAlpha * (expireTime - Time.time) / duration;
            

            gameObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, newAlpha);
            //Debug.Log(gameObject.renderer.material.color.ToString());
        }

        if (Time.time > expireTime)
        {
            Destroy(transform.root.gameObject);
        }

	}


}
