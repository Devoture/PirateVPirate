using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;
	public Image m_playerHUD;

	[SyncVar]
    public int currHealth = maxHealth;

    public void TakeDamage(int amount) {
    	currHealth -= amount;
		//UpdateHealth();
		if(currHealth < 0) {
			Destroy(this.gameObject);
		}
	}

	void UpdateHealth() {
		m_playerHUD.fillAmount = (float)currHealth / (float)maxHealth;
	}
}