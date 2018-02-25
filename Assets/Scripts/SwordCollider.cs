using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour {
	private float m_damage = 10.0f;
	private Animator m_animController;
	private Collider m_swordCollider;
	private bool m_hasDealtDamage = false;


	// Use this for initialization
	void Start () {
		m_animController = transform.root.GetComponent<Animator>();
		m_swordCollider = GetComponent<MeshCollider>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Enemy" && !m_hasDealtDamage) {
			if(other.GetComponent<Health>() != null) {
				m_hasDealtDamage = true;
				other.GetComponent<Health>().TakeDamage(m_damage);
			}
		}
	}

	public void StartAttack() {
		m_swordCollider.enabled = true;
	}

	public void BlockAttack() {
		m_swordCollider.enabled = true;
	}

	public void ResetAttack() {
		m_animController.SetBool("isAttacking", false);
		m_swordCollider.enabled = false;
		m_hasDealtDamage = false;
		

	}

	public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_swordCollider.enabled = false;
		m_hasDealtDamage = false;
		

	}
}
