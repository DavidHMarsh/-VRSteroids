using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class ShieldGraphicsManager : MonoBehaviour {

    public Image[] shieldGraphics;
    public int currentShieldValue;

    public ShipHealthManager shipHealthManager;

	// Use this for initialization

    

    void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        shipHealthManager = GetComponentInParent<ShipHealthManager>();
        if (shipHealthManager == null)
        {
            Debug.LogError("Error!  No ship health manager found in this hierarchy", this);
            return;
        }
        shipHealthManager.ShipHealthAdjustedEvent += ShipHealthManagerAltered;

    }

    private void Unsubscribe()
    {
        shipHealthManager.ShipHealthAdjustedEvent -= ShipHealthManagerAltered;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    public void SetShieldGraphics(int _value)
    {

        //Debug.Log("setting shield graphics", this);
        currentShieldValue = _value;
        for (int _i = 0; _i < shieldGraphics.Length; _i ++)
        {
            Image _foundGraphic = shieldGraphics[_i];
            if (_foundGraphic == null) Debug.Log("null graphic at index " + _i.ToString() + gameObject.name, this);
            Color _newColor;
            if (_foundGraphic.color == null)
            {
                _newColor = new Color(1,1,1,1);
            }
            else
            {
                _newColor = _foundGraphic.color;
            }

            if (_i + 1 > currentShieldValue)
            {
                _newColor.a = 0f;
                _foundGraphic.color = _newColor;
            }
            else
            {
                _newColor.a = 0.55f;
                _foundGraphic.color = _newColor;
            }
        }
    }

    public void ShipHealthManagerAltered(ShipHealthManager _shipHealthManager, int _data)
    {
        Debug.Log("Adjusted");
        SetShieldGraphics(_shipHealthManager.health.Health);
    }

}
