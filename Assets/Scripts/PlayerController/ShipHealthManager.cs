using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(HealthComponent))]
[RequireComponent(typeof(ThrustController))]

public class ShipHealthManager : MonoBehaviour {

    public HealthComponent health;
    public ShipUIManager uiManager;

    public bool deathTriggered = false;

    public Text deathText;
	// Use this for initialization

    void Start()
    {
        Subscribe();

        PlayerProfileManager.currentPlayer.timeGameStarted = Time.time;
    }

    private void Subscribe()
    {
        health.HealthDepletedEvent += HealthDepleted;

        health.HealthDamagedEvent += HealthDamaged;

        health.HealthAlteredEvent += HealthAltered;
    }

    private void Unsubscribe()
    {
        health.HealthDepletedEvent -= HealthDepleted;

        health.HealthDamagedEvent -= HealthDamaged;

        health.HealthAlteredEvent -= HealthAltered;
    }


    #region Events
    public delegate void ShipHealthManagerDelegate(ShipHealthManager _shipHealthManager, int _data);

    public event ShipHealthManagerDelegate ShipHealthDamagedEvent;

    public event ShipHealthManagerDelegate ShipHealthDepletedEvent;

    public event ShipHealthManagerDelegate ShipHealthAdjustedEvent;
    #endregion

    private int HealthDepleted(HealthComponent _health, int _value)
    {
        if (!deathTriggered)
        {
            if (ShipHealthDepletedEvent != null) ShipHealthDepletedEvent.Invoke(this, _value);
            StartCoroutine(DeathCoroutine());
        }

        return 0;
    }

    private int HealthDamaged(HealthComponent _health, int _value)
    {
        //Debug.Log("Damage");
        //uiManager.shieldGraphicsManager.SetShieldGraphics(_health.Health);

        if (ShipHealthDamagedEvent != null) ShipHealthDamagedEvent.Invoke(this, _value);

        

        return 0;
    }

    private int HealthAltered(HealthComponent _healthComponent, int _value)
    {
        if (ShipHealthAdjustedEvent != null) ShipHealthAdjustedEvent.Invoke(this, _value);

        return 0;
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private IEnumerator DeathCoroutine()
    {
        Debug.Log("Death!", this);

        deathTriggered = true;

        health.HealthLocked = true;

        PlayerProfileManager.currentPlayer.timeGameEnded = Time.time;

        PlayerProfileManager.currentPlayer.timeSurvived = PlayerProfileManager.currentPlayer.timeGameEnded - PlayerProfileManager.currentPlayer.timeGameStarted;


        deathText.color = Color.yellow;

        foreach (Component _component in this.gameObject.GetComponentsInChildren<Component>())
        {
            if (_component is IShipControl)
            {
                (_component as IShipControl).ShipControlActive(false);
            }
        }



        // set hud to RIP

        yield return new WaitForSeconds(1.5f);

        // Optional: Dissolve effect;

        Application.LoadLevel("NameEntryScene");

        yield return null;
    }


}
