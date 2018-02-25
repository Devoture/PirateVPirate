using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour {
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
		Debug.Log("hit something");
		if(other.tag == "Enemy" && !m_hasDealtDamage) {
			Debug.Log("hit enemy");
			if(other.GetComponent<Health>() != null) {
				Debug.Log("has health");
				m_hasDealtDamage = true;
				other.GetComponent<Health>().TakeDamage((int)m_damage);
				Debug.Log(other.GetComponent<Health>().GetHealth());
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
}
