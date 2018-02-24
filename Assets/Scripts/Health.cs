using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float m_maxHealth = 100.0f;
	
	private float m_currHealth;

	void Awake() {
		m_currHealth = m_maxHealth;
		UpdateHealthHUD();
	}

	void TakeDamage(float damage) {
		m_currHealth -= damage;
		if(m_currHealth <= 0) {
			m_currHealth = 0.0f;
		}
		UpdateHealthHUD();
	}

	void Heal(float healAmt) {
		m_currHealth += healAmt;
		if(m_currHealth >= 100) {
			m_currHealth = 100.0f;
		}
		UpdateHealthHUD();
	}

	void Died() {
		// dying stuff here
		Debug.Log("You Died");
	}

	void UpdateHealthHUD() {
		// dylan put your shit here fam
	}
}
