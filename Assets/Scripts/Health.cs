using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;
	public Image m_playerHUD;

	//[SyncVar(hook = "UpdateHealth")]
    public int m_currHealth;

	void Start() {
		m_currHealth = m_maxHealth;
	}

    public void TakeDamage(int damage) {
    	m_currHealth -= damage;
		UpdateHealth();
		if(m_currHealth <= 0) {
			Dead();
		}
	}

	void Update() {
		m_playerHUD.fillAmount = (float)m_currHealth / (float)m_maxHealth;
	}

	void Dead() {
		Destroy(this.gameObject);
	}

	public int GetCurrentHealth() {
		return m_currHealth;
	}

	public void UpdateHealth() {
		m_playerHUD.fillAmount = (float)m_currHealth / (float)m_maxHealth;
	}

}