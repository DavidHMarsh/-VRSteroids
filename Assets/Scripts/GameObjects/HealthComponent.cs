using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour
{

    private int health;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int healthMaximum;
    public int healthStartingValue;

    private bool healthLocked;

    public bool HealthLocked
    {
        get { return healthLocked; }
        set { 
            healthLocked = value;
            if (HealthLockedEvent != null) HealthLockedEvent.Invoke(this, value);
        }
    }



    #region Events
    public delegate int HealthComponentDelegate(HealthComponent _health, int _quantity);
    public delegate int HealthComponentLockedDelegate(HealthComponent _health, bool _locked);
    public event HealthComponentDelegate HealthDepletedEvent;

    public event HealthComponentDelegate HealthDamagedEvent;

    public event HealthComponentDelegate HealthHealedEvent;

    public event HealthComponentDelegate HealthAlteredEvent;

    public event HealthComponentDelegate HealthHealedAboveMaximumEvent;

    public event HealthComponentDelegate HealthSetEvent;

    public event HealthComponentLockedDelegate HealthLockedEvent;
    #endregion

    void Start()
    {
        health = healthStartingValue;
    }

    public void DamageHealth(int _damage)
    {
        if (healthLocked)
            return;
       
        health -= _damage;
        if (HealthDamagedEvent != null) HealthDamagedEvent.Invoke(this, _damage);
        if (HealthAlteredEvent != null) HealthAlteredEvent.Invoke(this, -_damage);
        if (health <= 0)
        {
            HealthDepletedEvent.Invoke(this, _damage);
        }
    }

    public void RecoverHealth(int _recovery)
    {
        if (healthLocked)
            return;

        bool _healedAboveMaximum = health + _recovery > healthMaximum;
        health += _recovery;

        if (health > healthMaximum)
        {
            health = healthMaximum;
        }

        if (HealthHealedEvent != null) HealthHealedEvent.Invoke(this, _recovery);
        if (HealthAlteredEvent != null) HealthAlteredEvent.Invoke(this, _recovery);
        if (_healedAboveMaximum)
            if (HealthHealedAboveMaximumEvent != null) HealthHealedAboveMaximumEvent.Invoke(this, _recovery);
    }

    public void AlterHealth(int _delta)
    {
        if (healthLocked)
            return;

        health += _delta;
        if (HealthAlteredEvent != null) HealthAlteredEvent.Invoke(this, _delta);
    }

    public void SetHealth(int _value)
    {
        if (healthLocked)
            return;

        health = _value;
        if (HealthSetEvent != null) HealthSetEvent.Invoke(this, _value);
    }

}
