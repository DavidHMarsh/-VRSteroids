using UnityEngine;
using System.Collections;

public class NameEntryButton : MonoBehaviour {

    public string stringSnippet;
    public StringBuilder stringBuilder;

	// Use this for initialization
    public virtual void Clicked()
    {
        stringBuilder.AddString(stringSnippet);
    }
}
