using UnityEngine;
using System.Collections;

public class CubicShadowClones : MonoBehaviour {

    // Creates a parallel objects in cubic cells around the object and moves them along

    public GameObject clonePrefab;
    public float parallelDistance;
    public int layers = 1;

    private Transform[] CLONES;
    private Vector3[] OFFSETS;
    private int iCells;

    // Use this for initialization
    void Start ()
    {
        parallelDistance = WraparoundSpace.xBound * 2;

        //Compute the number of cubic cells that will exist
        iCells = 2 * layers + 1;
        iCells = iCells * iCells * iCells - 1;
        
        //Debug.Log(iCells.ToString());
        CLONES = new Transform[iCells];
        OFFSETS = new Vector3[iCells];

        Vector3 vSpawn = Vector3.zero;
        GameObject gShadowClone;
        int i, j, k, n;
        n = 0;
        for (i = -1 * layers; i <= layers; i++)
        {
            for (j = -1 * layers; j <= layers; j++)
            {
                for (k = -1 * layers; k <= layers; k++)
                {
                    if (k == 0 && j == 0 && i == 0)
                    {
                        // do nothing at the center cell
                    }
                    else
                    {
                        vSpawn = parallelDistance * (i * Vector3.right + j * Vector3.up + k * Vector3.forward);
                        gShadowClone = Instantiate(clonePrefab, transform.position + vSpawn, transform.rotation) as GameObject;
                        //gNewCamera.GetComponent<ParallelCamera>().BaseCamera = transform;
                        CLONES[n] = gShadowClone.transform;
                        OFFSETS[n] = gShadowClone.transform.position - transform.position;
                        n++;
                    }
                }
            }
        }

    }
    
    void OnDestroy()
    {
        for (int i = 0; i < iCells; i++)
        {
            if (CLONES[i] != null)
            {
                Destroy(CLONES[i].gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        for (int i = 0; i < iCells; i++)
        {
            if (CLONES[i] != null)
            {
                CLONES[i].position = transform.position + OFFSETS[i];
                CLONES[i].rotation = transform.rotation;
            }
            else
            {
                Destroy(this.gameObject);
                break;
            }
        }
    }
}
