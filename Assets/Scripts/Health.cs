using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;
	public Image m_playerHUD;


	[SyncVar(hook = "UpdateHealth")]
    public int m_currHealth = m_maxHealth;

    public void TakeDamage(int damage) {
		if(isServer) {
    		m_currHealth -= damage;
		} else {
			CmdTakeDamage(damage);
		}
		if(m_currHealth <= 0) {
			Dead();
		}
	}

	[Command]
    void CmdTakeDamage(int damage) {
        TakeDamage(damage);
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