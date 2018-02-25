using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SwordCollider : NetworkBehaviour {

	public bool m_hasDealtDamage;

	private float m_damage = 10.0f;
	private Animator m_animController;
	private Health m_healthScript;

	void Start () {
		m_animController = transform.root.GetComponent<Animator>();
		m_healthScript = transform.root.GetComponent<Health>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Enemy") {
			Debug.Log("CANT TAKE IN SWORD: " + other.GetComponent<CharacterMovement>().m_cantTakeDamage);
			if(other.GetComponent<CharacterMovement>().CantBeDamaged()) {
				other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks++;
				Debug.Log("Blocking..." + other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks);
				Debug.Log("Number OF Blocked Attacks: " + other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks);
				m_animController.SetBool("blockedAttack", true);
			} 
			if(other.GetComponent<Health>() != null && !other.GetComponent<CharacterMovement>().m_cantTakeDamage) {
				other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				Debug.Log("Reset Blocked Number");
				other.GetComponent<Health>().TakeDamage((int)m_damage);
			}
			m_hasDealtDamage = true;
		}
	}

	public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}

	public void BlockedAttack() {
		m_animController.SetBool("blockedAttack", false);
	}
}
