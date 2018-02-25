using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	public float m_speed = 5.0f;
	public float m_speedMultiplier = 1.0f;
	public float m_gravity = 20.0f;
	public float m_jumpSpeed = 8.0f;

	private Vector3 m_moveDirection = Vector3.zero;
	private bool m_isJumping;
	private bool m_isGrounded = false;
	private CharacterController m_controller;
	private Animator m_animController;

	// Use this for initialization
	void Awake () {
		m_controller = GetComponent<CharacterController>();
		Camera.main.GetComponent<CameraController>().m_target = transform;
		m_animController = GetComponent<Animator>();
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


		if(Input.GetMouseButtonDown(0)) {
			m_animController.SetBool("isAttacking", true);
		}
	}
}

