using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CharacterMovement : NetworkBehaviour {
	public float m_speed = 5.0f;
	public float m_speedMultiplier = 1.0f;
	public float m_gravity = 20.0f;
	public float m_jumpSpeed = 8.0f;
	public MeshCollider m_swordCollider;

	private Vector3 m_moveDirection = Vector3.zero;
	private bool m_isJumping;
	private bool m_isGrounded = false;
	private CharacterController m_controller;
	private Animator m_animController;
	private SwordCollider m_swordColliderScript;
	private bool m_isAttacking;
	private Health m_healthScript;

	// Use this for initialization
	void Start() {
		m_controller = GetComponent<CharacterController>();
		Camera.main.GetComponent<CameraController>().m_target = transform;
		m_animController = GetComponent<Animator>();
		m_swordColliderScript = GetComponentInChildren<SwordCollider>();
		m_healthScript = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		m_moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if(Input.GetButtonDown("Jump") && m_isGrounded) {
			m_moveDirection.y = m_jumpSpeed;
			m_isJumping = true;
		}

		m_moveDirection *= m_speed * m_speedMultiplier;

		m_animController.SetFloat("Forward", m_moveDirection.z);
		m_animController.SetFloat("Right", m_moveDirection.x);

		m_moveDirection = transform.TransformDirection(m_moveDirection);
		

		m_moveDirection.y -= m_gravity * Time.deltaTime;
		m_isGrounded = ((m_controller.Move(m_moveDirection * Time.deltaTime)) & CollisionFlags.Below) != 0;


		if(Input.GetMouseButtonDown(0) && m_isAttacking == false) {
			m_swordCollider.enabled = true;			
			m_animController.SetBool("isAttacking", true);
			m_isAttacking = true;
			Debug.Log(m_animController.GetBool("isAttacking"));
		}

		if(Input.GetKeyDown(KeyCode.R)) {
			CmdTakeDamage();
		}
	}

	[Command]
	void CmdTakeDamage() {
		m_healthScript.TakeDamage(10);
	}

	public void ResetAttack() {
		if(m_animController != null) {
			m_animController.SetBool("isAttacking", false);
		}
		Debug.Log(m_animController.GetBool("isAttacking"));
		m_swordCollider.enabled = false;
		m_swordColliderScript.ResetAttack();
		m_isAttacking = false;
	}
}

