using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;
	public Image m_playerHUD;

    public int currHealth = maxHealth;

    public void TakeDamage(int amount) {
    	currHealth -= amount;
		Debug.Log(currHealth);
		UpdateHealth();
	}

	void UpdateHealth() {
		m_playerHUD.fillAmount = (float)currHealth / (float)maxHealth;
	}
}