using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class Health : NetworkBehaviour {

	public const float MAX_HEALTH = 100.0f;
	
	[SyncVar(hook = "UpdateHealthHUD")]
	private float m_currHealth;

	public Image m_HudFill;

	private float newUIUHealth;
	void Awake() {
		m_currHealth = MAX_HEALTH;
	}

	public void TakeDamage(float damage) {
		if(isServer) {
			m_currHealth -= damage;
			if(m_currHealth <= 0) {
				m_currHealth = 0.0f;
				Died();
			}
		}
	}

	public void Heal(float healAmt) {
		if(isServer) {
			m_currHealth += healAmt;
			if(m_currHealth >= 100) {
				m_currHealth = 100.0f;
			}
		}
	}

	void Died() {
		// dying stuff here
		Debug.Log("You Died");
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.A)){
			TakeDamage(10);
		}
	}

	void UpdateHealthHUD(float currHealth) {
		newUIUHealth = currHealth / MAX_HEALTH;
		m_HudFill.fillAmount = newUIUHealth;
	}
}
