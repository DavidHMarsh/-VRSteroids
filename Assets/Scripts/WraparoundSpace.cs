using UnityEngine;
using System.Collections;

public class WraparoundSpace : MonoBehaviour {

    public static float xBound;
    public static float yBound;
    public static float zBound;

    private float fBoundary = 600.0f;

    private static Vector3 vOffset;

    // Use this for initialization
    void Start ()
    {
        xBound = fBoundary;
        yBound = fBoundary;
        zBound = fBoundary;
    }
    
    private float CorrectedCoordinate(float coordinate, float bound)
    {
        if (Mathf.Abs(coordinate) > bound)
        {
            return coordinate - 2 * Mathf.Sign(coordinate) * bound;
        }

        return coordinate;
        
    }

    /*void onTriggerEnter(Collider other)
    {
        Debug.Log("Out of bounds!!!");


        float fNewX = CorrectedCoordinate(transform.position.x, xBound);
        float fNewY = CorrectedCoordinate(transform.position.y, yBound);
        float fNewZ = CorrectedCoordinate(transform.position.z, zBound);

        other.transform.position = new Vector3(fNewX, fNewY, fNewZ);

    }*/

    // Update is called once per frame
    void Update ()
    {

        if( Mathf.Abs(transform.position.x) > xBound 
            || Mathf.Abs(transform.position.y) > yBound
            || Mathf.Abs(transform.position.z) > zBound)
        {
            float fNewX = CorrectedCoordinate(transform.position.x, xBound);
            float fNewY = CorrectedCoordinate(transform.position.y, yBound);
            float fNewZ = CorrectedCoordinate(transform.position.z, zBound);

            transform.position = new Vector3(fNewX, fNewY, fNewZ);
        }

    }
}
