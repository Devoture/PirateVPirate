using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class CharacterMovement : NetworkBehaviour {
	public float m_speed = 5.0f;
	public float m_speedMultiplier = 1.0f;
	public float m_gravity = 20.0f;
	public SoundMGR m_soundManager;
	public bool m_hasClicked = false;
	public float m_jumpSpeed = 8.0f;
	public float m_verticalVelocity;
	public MeshCollider m_swordCollider;
	public int m_numOfBlockedAttacks = 0;
	public bool m_cantTakeDamage = false;
	public GameObject m_camtarget;
	public bool m_isDead = false;

	private Vector3 m_moveDirection = Vector3.zero;
	private bool m_isJumping;
	private bool m_isGrounded = false;
	private CharacterController m_controller;
	public Animator m_animController;
	public HitCollider m_hitColliderScript;
	private bool m_isAttacking;
	public Health m_healthScript;
	private bool m_disableMovement;

	// Use this for initialization
	void Start() {
		m_controller = GetComponent<CharacterController>();
		Camera.main.GetComponent<CameraController>().m_target = transform;
		if(gameObject.tag == "Player"){
			gameObject.layer = 8;
		}
		else if(gameObject.tag == "Enemy"){
			gameObject.layer = 9;
		}
		m_animController = GetComponent<Animator>();
		m_hitColliderScript = GetComponent<HitCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.m_gameStarted) {
			if(!m_disableMovement) {
				m_moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

				if(m_isGrounded) {
					m_verticalVelocity = -m_gravity * Time.deltaTime;
					if(Input.GetButtonDown("Jump")) {
						m_isGrounded = false;
						m_verticalVelocity = m_jumpSpeed;
						m_isJumping = true;
					}
				} else {
					m_verticalVelocity -= m_gravity * Time.deltaTime;
				}

				Vector3 jumpVector = new Vector3(0, m_verticalVelocity, 0);
        		m_controller.Move (jumpVector * Time.deltaTime);

				m_moveDirection *= m_speed * m_speedMultiplier;

				m_animController.SetFloat("Forward", m_moveDirection.z);
				m_animController.SetFloat("Right", m_moveDirection.x);

				m_moveDirection = transform.TransformDirection(m_moveDirection);

				m_controller.Move(m_moveDirection * Time.deltaTime);

				if(Input.GetMouseButtonDown(0) && m_isAttacking == false) {
					m_swordCollider.enabled = true;			
					m_animController.SetBool("isAttacking", true);
					m_isAttacking = true;
				}

				if(Input.GetMouseButtonUp(0)) {
					m_animController.SetBool("isAttacking", false);
					m_hitColliderScript.m_hasDealtDamage = false;
				}
			}

			if(Input.GetMouseButtonDown(1) && m_numOfBlockedAttacks <= 3) {
				ResetAttack();
				m_disableMovement = true;
				m_animController.SetBool("isBlocking", true);
				m_cantTakeDamage = true;
			}

			if(Input.GetMouseButtonUp(1)) {
				m_disableMovement = false;
				m_animController.SetBool("isBlocking", false);
				m_cantTakeDamage = false;
			}

			// if(Input.GetKeyDown(KeyCode.R)) {
			// 	m_healthScript.TakeDamage(10);
			// }
		}
		Debug.Log("Is local: " + isLocalPlayer);
	}

	public void TakeDamage(int damage) {
		if(isLocalPlayer) {
			Debug.Log("in take damage");
			m_healthScript.CmdTakeDamage(damage);
		}
	}

	// [Command]
	// void CmdTakeDamage(int damage) {
	// 	m_healthScript.Ta
	// }

	void OnControllerColliderHit(ControllerColliderHit other) {
		if(other.gameObject.tag == "Ground") {
			m_isGrounded = true;
		}
	}

	void BlockedAttack() {
		m_animController.SetBool("blockedAttack", false);
	}

	public void ResetAttack() {
		Debug.Log("hi");
		m_swordCollider.enabled = false;
		m_hitColliderScript.m_hasDealtDamage = false;
		m_isAttacking = false;
	}

	public void GameOver() {
		if(isLocalPlayer) {
			if(!m_isDead) {
				SceneManager.LoadScene("Win");
			}
		}
	}
}

