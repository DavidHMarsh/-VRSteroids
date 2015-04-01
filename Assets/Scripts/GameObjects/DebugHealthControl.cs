using UnityEngine;
using System.Collections;

public class DebugHealthControl : MonoBehaviour {

#if UNITY_EDITOR
    public HealthComponent health;
	// Use this for initialization
    
    public void CauseDamage()
    {
        health.DamageHealth(1);
    }

    public void CauseHeal()
    {
        health.RecoverHealth(1);
    }

    void OnGUI()
    {
       if ( GUILayout.Button("Damage " + health.gameObject.name))
       {
           CauseDamage();
       }

       if (GUILayout.Button("Heal " + health.gameObject.name))
       {
           CauseHeal();
       }
    }
#endif
}
