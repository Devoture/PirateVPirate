using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;
	public Image m_playerHUD;

	[SyncVar]
    public int m_currHealth = m_maxHealth;

    public void TakeDamage(int amount) {
    	m_currHealth -= amount;
		UpdateHealth();
		if(m_currHealth <= 0) {
			Dead();
		}
	}

	void Dead() {
		Destroy(this.gameObject);
	}

	public int GetCurrentHealth() {
		return m_currHealth;
	}

	void UpdateHealth() {
		m_playerHUD.fillAmount = (float)m_currHealth / (float)m_maxHealth;
	}
}