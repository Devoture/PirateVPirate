using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;

	[SyncVar]
    public int m_currHealth;

	public CharacterMovement m_playerScript;
	public HUDScript m_hudScript;

	void Start() {
		m_currHealth = m_maxHealth;
		UpdateHUD();
		m_playerScript = GetComponent<CharacterMovement>();
		m_hudScript = GameManager.Instance.m_hud.GetComponent<HUDScript>();
	}

    public void TakeDamage(int damage) {
    	m_currHealth -= damage;
		UpdateHUD();
		if(m_currHealth <= 0) {
			Dead();
		}
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

	public void UpdateHUD() {
		m_hudScript.UpdateHUD(this.gameObject);
	}
}