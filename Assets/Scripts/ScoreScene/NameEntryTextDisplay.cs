using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class NameEntryTextDisplay : MonoBehaviour {

    public Text textComponent;
    public StringBuilder stringBuilder;

   void Update()
    {
        textComponent.text  = stringBuilder.builtString;
    }
}
