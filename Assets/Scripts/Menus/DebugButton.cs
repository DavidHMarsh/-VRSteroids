using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DebugButton : MonoBehaviour {

    void Awake()
    {
        FitColliderToButtonVisuals();
        
    }

	// Use this for initialization
    
	public void Clicked()
    {
        Debug.Log("button clicked with name " + this.name);
    }

    public void FitColliderToButtonVisuals()
    {
        if (collider != null && collider is BoxCollider)
        {
            BoxCollider _boxCollider = collider as BoxCollider;

            Vector2 _buttonSize = (Vector3)(GetComponent<UnityEngine.UI.Button>().transform as RectTransform).sizeDelta;

            _boxCollider.size = new Vector3(_buttonSize.x, _buttonSize.y, 1);
        }
    }

    /*
    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("Pointer click");
    }*/
}
