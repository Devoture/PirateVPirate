using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour {

	private CharacterController m_characterController;
	private Animator m_animController;
	private Collider swordCollider;

	// Use this for initialization
	void Start () {
		m_characterController = transform.root.GetComponent<CharacterController>();
		m_animController = transform.root.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) {
		
	}

	public void StartAttack() {

	}

	public void BlockAttack() {
		
	}

	public void ResetAttack() {
		m_animController.SetBool("isAttacking", false);
		

	}

	public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		

	}
}
