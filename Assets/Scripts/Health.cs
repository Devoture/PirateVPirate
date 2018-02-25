using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
    public const int m_maxHealth = 100;
	public Image m_healthHUD;

	[SyncVar(hook = "UpdateHUD")]
	private int m_currHealth = m_maxHealth;

	public void TakeDamage(int damage) {
		if(isServer) {
			m_currHealth -= damage;
			if(m_currHealth <= 0) {
				m_currHealth = 0;
				Died();
			}
			//UpdateHUD(m_currHealth);
		}
	}

	void Died() {
		// dying stuff here
		Destroy(this.gameObject);
	}

	void UpdateHUD(int health) {
		m_healthHUD.fillAmount = (float)health / (float)m_maxHealth;
	}
}