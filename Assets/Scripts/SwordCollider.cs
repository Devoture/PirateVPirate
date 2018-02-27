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
		var hit = other.gameObject;
		var hitPlayer = hit.GetComponent<Health>();
		if(other.tag == "Enemy" && !m_hasDealtDamage) {
			if(other.GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
				other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks++;
				Debug.Log("Blocking..." + other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks);
				Debug.Log("Number OF Blocked Attacks: " + other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks);
				other.GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
			} 
			if(hitPlayer != null) {
				if(other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks > 3) {
					other.GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
					other.GetComponent<CharacterMovement>().m_animController.SetBool("isBlocking", false);
					other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
				if(!other.GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
					hitPlayer.CmdTakeDamage(10);
					Debug.Log("Take damage");
					Debug.Log(hitPlayer.GetCurrentHealth());
					other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
			}
			m_hasDealtDamage = true;
		}
	}

	public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}
}
