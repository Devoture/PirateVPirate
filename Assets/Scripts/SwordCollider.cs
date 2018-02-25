using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SwordCollider : NetworkBehaviour {
	private float m_damage = 10.0f;
	private Animator m_animController;
	private bool m_hasDealtDamage = false;


	// Use this for initialization
	void Start () {
		m_animController = transform.root.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Enemy" && !m_hasDealtDamage) {
			if(other.GetComponent<Health>() != null) {
				if(isLocalPlayer) {
					CmdTakeDamage(other);
				}
			}
		}
	}

	[Command]
	void CmdTakeDamage(Collider other) {
		m_hasDealtDamage = true;
		other.GetComponent<Health>().TakeDamage((int)m_damage);
	}

	public void ResetAttack() {
		m_hasDealtDamage = false;
	}

	public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}
}
