using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {

	public bool m_hasDealtDamage;
	private float m_damage = 10.0f;
	private Animator m_animController;
	private Health m_healthScript;

	// Use this for initialization
	void Start () {
		m_healthScript = GetComponent<Health>();
		m_animController = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(this.tag == "Enemy") {
			if(other.name == "Sword" && !m_hasDealtDamage) {
				if(GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks++;
					GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
				} 
				if(GetComponent<CharacterMovement>().m_numOfBlockedAttacks > 3) {
					GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
					GetComponent<CharacterMovement>().m_animController.SetBool("isBlocking", false);
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
				if(!GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
					m_healthScript.CmdTakeDamage(10);
					Debug.Log(m_healthScript.GetCurrentHealth());
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
			}
		}
		
		m_hasDealtDamage = true;
	}

		public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}
}
