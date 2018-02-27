using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;
	public Image m_playerHUD;

	[SyncVar(hook = "UpdateHealth")]
    public int m_currHealth;

	private CharacterMovement m_playerScript;

	void Start() {
		m_currHealth = m_maxHealth;
		m_playerScript = GetComponent<CharacterMovement>();
	}

    public void TakeDamage(int damage) {
    	m_currHealth -= damage;
		if(m_currHealth <= 0) {
			Dead();
		}
	}

	void Update() {
		m_playerHUD.fillAmount = (float)m_currHealth / (float)m_maxHealth;
	}

	void Dead() {
		GameManager.Instance.m_gameStarted = false;
		this.gameObject.SetActive(false);
		m_playerScript.m_isDead = true;
		GameManager.Instance.CheckGameOver();
	}

	public int GetCurrentHealth() {
		return m_currHealth;
	}

	public void UpdateHealth(int health) {
		m_playerHUD.fillAmount = (float)health / (float)m_maxHealth;
	}
}