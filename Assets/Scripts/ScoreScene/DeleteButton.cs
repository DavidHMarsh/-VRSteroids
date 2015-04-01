using UnityEngine;
using System.Collections;

public class DeleteButton : NameEntryButton
{
    // Use this for initialization
    public override void Clicked()
    {
        stringBuilder.DeleteCharacter(1);
    }
}
