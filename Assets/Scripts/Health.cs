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
	public int m_pirate1Health;

	private GameObject m_pirate1;

	void Start() {
		m_currHealth = m_maxHealth;
		UpdateHUD();
		m_playerScript = GetComponent<CharacterMovement>();
		m_hudScript = GameManager.Instance.m_hud.GetComponent<HUDScript>();
		if(!isServer) {
			m_pirate1 = GameObject.FindGameObjectWithTag("Enemy");
		}
	} 

	void Update() {
		if(!isServer) {
			UpdateHUD();
			m_pirate1Health = m_pirate1.GetComponent<Health>().GetCurrentHealth();
		}
		if(isServer) {
			m_hudScript.Pirate1UpdateHUD(m_pirate1Health);
		}
	}

    public void TakeDamage(int damage) {
    	m_currHealth -= damage;
		UpdateHUD();
		if(m_currHealth <= 0) {
			Dead();
		}
	}

	[Command]
	public void CmdTakeDamage(int damage) {
		TakeDamage(damage);
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