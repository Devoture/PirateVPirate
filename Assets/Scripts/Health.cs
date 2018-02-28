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
		m_playerScript = GetComponent<CharacterMovement>();
		m_hudScript = GameManager.Instance.m_hud.GetComponent<HUDScript>();
	}

    public void TakeDamage(int damage) {
    	m_currHealth -= damage;
		CmdUpdateHUD();
		if(m_currHealth <= 0) {
			Dead();
		}
	}

	[Command]
	void CmdUpdateHUD() {
		m_hudScript.UpdateHUD(this.gameObject);
	}

	void Dead() {
		GameManager.Instance.m_gameStarted = false;
		m_playerScript.m_isDead = true;
		this.gameObject.SetActive(false);
		GameManager.Instance.CheckGameOver();
		if(isLocalPlayer) {
			SceneManager.LoadScene("Lose");
		}
	}

	public int GetCurrentHealth() {
		return m_currHealth;
	}

	// public void UpdateHealth(int health) {
	// 	m_currHealth = health;
	// 	if(isServer) {
	// 		m_playerHUD.fillAmount = (float)health / (float)m_maxHealth;
	// 	} else {
	// 		m_playerHUD2.fillAmount = (float)health / (float)m_maxHealth;
	// 	}
	// }
}