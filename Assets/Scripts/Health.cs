using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;

    [SyncVar]
    public int health = maxHealth;

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        health -= amount;
		Debug.Log("took: " + health);
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Dead!");
        }
    }
}