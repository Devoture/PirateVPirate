using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SwordCollider : NetworkBehaviour {

	private float m_damage = 10.0f;
	private Animator m_animController;
	private bool m_hasDealtDamage = false;
	private Health m_healthScript;
	private CharacterMovement m_charScript;

	void Start () {
		m_animController = transform.root.GetComponent<Animator>();
		m_healthScript = transform.root.GetComponent<Health>();
		m_charScript = transform.root.GetComponent<CharacterMovement>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Enemy" && !m_hasDealtDamage) {
			if(m_healthScript.m_cantTakeDamage) {
				m_charScript.m_numOfBlockedAttacks++;
				Debug.Log("Number OF Blocked Attacks: " + m_charScript.m_numOfBlockedAttacks);
				m_animController.SetBool("blockedAttack", true);
			}
			if(other.GetComponent<Health>() != null) {
				m_charScript.m_numOfBlockedAttacks = 0;
				Debug.Log("Reset Blocked Number");
				m_hasDealtDamage = true;
				other.GetComponent<Health>().RpcTakeDamage((int)m_damage);
			}
		}
	}

	public void ResetAttack() {
		m_hasDealtDamage = false;
	}

	public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}

	public void BlockedAttack() {
		m_animController.SetBool("blockedAttack", false);
	}
}
