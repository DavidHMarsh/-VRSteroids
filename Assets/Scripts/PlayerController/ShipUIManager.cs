using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipUIManager : MonoBehaviour {

    public Text alertText;
    public ShipHealthManager shipHealthManager;


    // public Graphic textDire;
    //public Graphic textRIP;

    void Start()
    {
        shipHealthManager = gameObject.GetComponentInParent<ShipHealthManager>();
        Subscribe();
    }

    void Subscribe()
    {
        shipHealthManager.ShipHealthDamagedEvent += ShipDamaged;

    }

    void Unsubscribe()
    {
        shipHealthManager.ShipHealthDamagedEvent -= ShipDamaged;
    }

    void OnDestroy()
    {
        Unsubscribe();
    }

    void ShipDamaged(ShipHealthManager _healthManager, int _value)
    {
        if (_healthManager.health.Health == 0)
        {
            DisplayAlertText("RIP", Color.blue);
        }

        else if (_healthManager.health.Health == 1)
        {
            DisplayAlertText("danger!", Color.red);
        }

        else
        {
            DisplayAlertText("Hit!", Color.yellow);
        }
    }


	// Update is called once per frame
	public void DisplayAlertText(string _text, Color _color)
    {
        alertText.text = _text;
        alertText.color = _color;

        alertText.GetComponent<Animator>().Play("ShowAlertText");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DisplayAlertText("Cyan", Color.cyan);
        }
    }

    [ContextMenu("Test Text")]
    public void TestText()
    {
        DisplayAlertText("Testing", Color.green);
    }
}
