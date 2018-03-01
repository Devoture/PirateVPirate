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
		if((other.name == "Sword" && !m_hasDealtDamage) && this.tag == "Enemy") {
			if(this.GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
				this.GetComponent<CharacterMovement>().m_numOfBlockedAttacks++;
				this.GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
			} 
			if(this.GetComponent<CharacterMovement>().m_numOfBlockedAttacks > 3) {
				this.GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
				this.GetComponent<CharacterMovement>().m_animController.SetBool("isBlocking", false);
				this.GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
			}
			if(!this.GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
				this.GetComponent<CharacterMovement>().TakeDamage(10);
				Debug.Log("Take damage");
				Debug.Log(m_healthScript.GetCurrentHealth());
				this.GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
			m_hasDealtDamage = true;
		}
	}

		public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}
}
