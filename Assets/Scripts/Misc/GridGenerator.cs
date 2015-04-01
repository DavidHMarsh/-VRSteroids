using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GridGenerator : MonoBehaviour
{
    public uint gridWidth = 1;
    public uint gridHeight = 1;
    public uint defaultGridSpaceWidth;
    public uint defaultGridSpaceHeight;
    public Vector3 startingCoordinate;
    public Vector3 gridMargin = Vector3.zero;

    public bool generateLeftToRight = false;
    public bool generateDownToUp = true;
    public bool useStartingCoordinateAsCenterOfGrid;


    // Use this for initialization

    public List<Vector3> GenerateGridCoordinates(uint? width = null, uint? height = null, GameObject _sizeObject = null)
    {
        if (width == null) width = gridWidth;
        if (height == null) height = gridHeight;
        Vector3 _spaceDimension = Vector3.zero;
        if (_sizeObject == null) _spaceDimension = new Vector3(defaultGridSpaceWidth, defaultGridSpaceHeight, 0);
        else
        {

            SpriteRenderer _spriteRenderer = _sizeObject.GetComponent<SpriteRenderer>();
            if (_sizeObject.collider != null)
            {
                // TODO make the collider bounds work for a prefab;
                Debug.Log("Collider found on target object " + _sizeObject.name + " With bounds of " + _sizeObject.collider.bounds.size.ToString());

                _spaceDimension.x = _sizeObject.collider.bounds.size.x;
                _spaceDimension.y = _sizeObject.collider.bounds.size.y;
            }
            else if (_spriteRenderer != null)
            {
                Debug.Log("Sprite found " + _spriteRenderer.sprite.bounds.size.x.ToString() + " " + _spriteRenderer.sprite.bounds.size.y.ToString(), _sizeObject);
                _spaceDimension.x = _spriteRenderer.sprite.bounds.size.x * _sizeObject.transform.localScale.x;
                _spaceDimension.y = _spriteRenderer.sprite.bounds.size.y * _sizeObject.transform.localScale.y;
            }
            
        }

        List<Vector3> outputList = new List<Vector3>();
        Vector3 newVector = Vector3.zero;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {

                newVector.x = (x * (_spaceDimension.x + gridMargin.x) * (generateLeftToRight ? -1 : 1));
                newVector.y = (y * (_spaceDimension.y + gridMargin.y)  * (generateDownToUp ? 1 : -1));
                outputList.Add(newVector);

            }
        }
        // if Centering, find the difference between the first and last grid point and move every point by half of the difference.
        if (useStartingCoordinateAsCenterOfGrid)
        {
            Vector3 centerOffset = (outputList[0] - outputList[outputList.Count - 1]) / 2;

            for (int i = 0; i < outputList.Count; i++)
            {
                outputList[i] = outputList[i] + centerOffset;
            }
        }

        return outputList;
    }

}