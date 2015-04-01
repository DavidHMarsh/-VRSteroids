using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ToggleOculusAndRealCamera : MonoBehaviour
{
    public static ToggleOculusAndRealCamera Instance;
    // Use this for initialization
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this);
    }
    void Start()
    {

    }

    // Update is called once per frame
#if UNITY_EDITOR
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TurnOffVRCameras();

        }
    }

    void TurnOffVRCameras()
    {
        OVRCameraRig _foundRig = FindObjectOfType<OVRCameraRig>();
        if (_foundRig == null || _foundRig.enabled == false)
        {

        }
        else
        {
            _foundRig.enabled = false;
            _foundRig.GetComponent<OVRManager>().enabled = false;
            Camera _newCamera = _foundRig.centerEyeAnchor.gameObject.AddComponent<Camera>();
            _newCamera.fieldOfView = _foundRig.leftEyeCamera.fieldOfView;
        }

        StereoController _stereoCamera = FindObjectOfType<StereoController>();

        if (_stereoCamera != null)
        {
            Debug.Log("Found stereo camera", _stereoCamera);
            _stereoCamera.enabled = false;
        }
        else
        {
            Debug.Log("no stereo camera found");
        }
    }
#endif
}
