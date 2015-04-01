using UnityEngine;
using UnityEngine.EventSystems;

//by Ralph Barbagallo
//www.flarb.com
//www.ralphbarbagallo.com
//@flarb

public class VRInputModule : BaseInputModule
{

    public static GameObject targetObject;

    static VRInputModule _singleton;

    void Awake()
    {
        _singleton = this;
    }

    public override void Process()
    {
        if (targetObject == null)
            return;

        
        /*
        if (Input.GetMouseButtonDown(0))
        { //I poll my own inputmanager class to see if the select button has been pressed

            //We tapped the select button so SUBMIT (not select).
            BaseEventData data = GetBaseEventData();
            data.selectedObject = targetObject;
            Debug.Log(data.ToString());
            Debug.Break();
            ExecuteEvents.Execute(targetObject, data, ExecuteEvents.submitHandler);
        }*/
    }


    static RaycastHit rayHit;

    public void Update()
    {
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out rayHit);

        if (rayHit.collider != null)
            SetTargetObject(rayHit.collider.gameObject);
        else
            SetTargetObject(null);
        
        //if (Input.GetButtonDown("Submit"))
        if (Input.GetButtonDown("Fire"))  
        {
            //Debug.Log("submitting");
            PointerEventData pEvent = new PointerEventData(_singleton.eventSystem);
            pEvent.clickCount = 1;

            ExecuteEvents.Execute(targetObject, pEvent, ExecuteEvents.pointerClickHandler);
        }
    }

    public static void SetTargetObject(GameObject obj)
    {

        //we're hovering over a new object, so unhover the current one
        if ((targetObject != null) && (targetObject != obj))
        {
            PointerEventData pEvent = new PointerEventData(_singleton.eventSystem);
            pEvent.worldPosition = rayHit.point;
            ExecuteEvents.Execute(targetObject, pEvent, ExecuteEvents.pointerExitHandler);
        }

        if (obj != null)
        {

            //this is the same object that was hovered last time, so bail
            if (obj == targetObject)
                return;

            //we've entered a new GUI object, so excute that event to highlight it
            PointerEventData pEvent = new PointerEventData(_singleton.eventSystem);
            pEvent.pointerEnter = obj;
            pEvent.worldPosition = rayHit.point;

            ExecuteEvents.Execute(obj, pEvent, ExecuteEvents.pointerEnterHandler);
        }

        targetObject = obj;
    }

}