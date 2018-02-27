using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;
	public Image m_playerHUD;

	[SyncVar(hook = "UpdateHealth")]
    public int m_currHealth = m_maxHealth;

    public void TakeDamage(int amount) {
    	m_currHealth -= amount;
		if(m_currHealth <= 0) {
			Dead();
		}
	}

	void Dead() {
		this.gameObject.SetActive(false);
	}

	void UpdateHealth() {
		m_playerHUD.fillAmount = (float)m_currHealth / (float)m_maxHealth;
	}
}