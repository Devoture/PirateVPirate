using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Health : NetworkBehaviour {

    public const int m_maxHealth = 100;

	[SyncVar(hook = "ChangeHealth")]
    public int m_currHealth;

	public CharacterMovement m_playerScript;
	public HUDScript m_hudScript;

	void Awake() {
		m_hudScript = GameManager.Instance.m_hud.GetComponent<HUDScript>();
	}

	void Start() {
		
		m_currHealth = m_maxHealth;
		//UpdateHUD();
		m_playerScript = GetComponent<CharacterMovement>();
	} 

	[Command]
	public void CmdTakeDamage(int damage) {
		if(isLocalPlayer) {
			Debug.Log("Poop");
			TakeDamage(damage);
		} else {
			Debug.Log("ASASA");
		}
	}

	public void TakeDamage(int damage) {
		m_currHealth -= damage;
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

	public void ChangeHealth(int health) {
		m_currHealth = health;
		m_hudScript.UpdateHUD(this.gameObject, health);
	}
}