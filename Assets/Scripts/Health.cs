using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;
	public Image m_playerHUD;
	public Image m_playerHUD2;

	[SyncVar(hook = "UpdateHealth")]
    public int m_currHealth;

	public CharacterMovement m_playerScript;

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
		m_playerScript.m_isDead = true;
		this.gameObject.SetActive(false);
		GameManager.Instance.CheckGameOver();
		SceneManager.LoadScene("Lose");
	}

	public int GetCurrentHealth() {
		return m_currHealth;
	}

	public void UpdateHealth(int health) {
		m_currHealth = health;
		if(isServer) {
			m_playerHUD.fillAmount = (float)health / (float)m_maxHealth;
		} else {
			m_playerHUD2.fillAmount = (float)health / (float)m_maxHealth;
		}
	}
}