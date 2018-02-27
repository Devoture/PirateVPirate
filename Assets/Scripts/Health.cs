using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;
	public Image m_playerHUD;

	[SyncVar(hook = "UpdateHealth")]
    public int m_currHealth = m_maxHealth;

	[Command]
    public void CmdTakeDamage(int amount) {
    	m_currHealth -= amount;
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