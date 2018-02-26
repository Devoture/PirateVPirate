using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;

    public int currHealth = maxHealth;

    public void TakeDamage(int amount) {
    	currHealth -= amount;
		Debug.Log(currHealth);
	}

	void UpdateHealth(int health) {
		currHealth = health;
	}
}