using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;
	public Image m_playerHUD;



    public int m_currHealth;

	void Start() {
		m_currHealth = m_maxHealth;
	}

    public void TakeDamage(int damage) {
    	m_currHealth -= damage;
		UpdateHealth(m_currHealth);
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

	void UpdateHealth(int health) {
		m_playerHUD.fillAmount = (float)health / (float)m_maxHealth;
	}
}