using UnityEngine;
using System.Collections;

public class StringBuilder : MonoBehaviour {

    public string builtString = "";

    public int maximumStringLength = 10;

    void Awake()
    {
        if (maximumStringLength <= 0)
        {
            Debug.LogError("Quantity of characters to delete is invalid :" + maximumStringLength.ToString(), this);
        }
    }

    public void AddString(string _snippet)
    {
        
        builtString = string.Concat(builtString, _snippet);
        if (builtString.Length > 10)
        {
            // TODO clean up this method?
            builtString = builtString.Remove(maximumStringLength);
        }
    }

    public void AddCharacter(char _char)
    {
        AddString(_char.ToString());
    }


    public void Clear()
    {
        builtString = "";
    }

    public void DeleteCharacter(int _quantity = 1)
    {
        if (_quantity <= 0)
        {
            Debug.LogError("Quantity of characters to delete is invalid :" + _quantity.ToString(), this);
        }
        else
        {
            if (_quantity > builtString.Length) 
                Clear();
            else
            {
                builtString = builtString.Remove(builtString.Length - _quantity);
            }
        }
    }

}
