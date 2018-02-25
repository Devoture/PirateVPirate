using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	
    public const int m_maxHealth = 100;
	public Image m_healthHUD;

	[SyncVar(hook = "UpdateHUD")]
	
	public int m_currHealth = m_maxHealth;
	public bool m_cantTakeDamage = false;
	public bool m_Destroy;

	public void TakeDamage(int damage) {
		if(isServer){
			m_currHealth -= damage;
			if(m_currHealth <= 0){
				if(m_Destroy){
					Destroy(gameObject);
				}
			}
		}
	if(isClient){
			m_currHealth -= damage;
			if(m_currHealth <= 0){
				if(m_Destroy){
					Destroy(gameObject);
				}
			}
		}
	}

	public int GetHealth() {
		return m_currHealth;
	}

	void UpdateHUD(int m_currHealth) {
		m_healthHUD.fillAmount = (float)m_currHealth / (float)m_maxHealth;
	}
}