using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class CharacterMovement : NetworkBehaviour {
	public float m_speed = 5.0f;
	public float m_speedMultiplier = 1.0f;
	public float m_gravity = 20.0f;
	public AudioSource m_swordSource;
	public bool m_hasClicked = false;
	public float m_jumpSpeed = 8.0f;
	public float m_verticalVelocity;
	public MeshCollider m_swordCollider;
	public int m_numOfBlockedAttacks = 0;
	public bool m_cantTakeDamage = false;
	public GameObject m_camtarget;
	public bool m_isDead = false;
	public AudioClip m_swipe1;
	public AudioClip m_swipe2;
	public Animator m_animController;
	public HitCollider m_hitColliderScript;
	public bool m_inMenu;
	public Health m_healthScript;

	private Vector3 m_moveDirection = Vector3.zero;
	private bool m_isJumping;
	private bool m_isGrounded = false;
	private CharacterController m_controller;
	private bool m_isAttacking;
	private bool m_disableMovement;
	private int randNum;
	private NetworkManager m_networkManager;
	
	void Start() {
		m_networkManager = NetworkManager.singleton;
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
	
	void Update () {
		Debug.Log(m_isDead);
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
					m_swipeSound();
					if(isLocalPlayer) {
						CmdSetSwordCollider(true);
						if(isServer) {
							RpcSetSwordCollider(true);
						}
					}
					m_swordCollider.enabled = true;
					m_animController.SetBool("isAttacking", true);
					m_isAttacking = true;
				}

				if(Input.GetMouseButtonUp(0)) {
					m_animController.SetBool("isAttacking", false);
				}
			}
			if(Input.GetKeyDown(KeyCode.Escape) && !m_inMenu) {
				m_disableMovement = true;
				StateManager.Instance.EnableOptionScreen();
				m_inMenu = true;
			} else if(Input.GetKeyDown(KeyCode.Escape) && m_inMenu) {
				m_disableMovement = false;
				StateManager.Instance.DisableAll();
				m_inMenu = false;
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
		}
	}

	[Command]
	public void CmdSetSwordCollider(bool activeStatus) {
		m_swordCollider.enabled = activeStatus;	
	}

	[ClientRpc]
	public void RpcSetSwordCollider(bool activeStatus) {
		m_swordCollider.enabled = activeStatus;	
	}

	public void m_swipeSound(){
		randNum = Random.Range(1,3);

		if(randNum == 1){
			m_swordSource.PlayOneShot(m_swipe1);
		}
		if(randNum == 2){
			m_swordSource.PlayOneShot(m_swipe2);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit other) {
		if(other.gameObject.tag == "Ground") {
			m_isGrounded = true;
		}
	}

	void BlockedAttack() {
		m_animController.SetBool("blockedAttack", false);
	}

	public void ResetAttack() {
		if(isLocalPlayer) {
			CmdSetSwordCollider(false);
			if(isServer) {
				RpcSetSwordCollider(false);
			}
		}
		m_hitColliderScript.m_hasDealtDamage = false;
		m_isAttacking = false;
	}

	public void Dead() {
		m_isDead = true;
		gameObject.SetActive(false);
		GameManager.Instance.CheckGameOver();
	}

	public void GameOver() {
		if(isLocalPlayer) {
			MatchInfo matchInfo = m_networkManager.matchInfo;
			m_networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, m_networkManager.OnDropConnection);
			m_networkManager.StopHost();
			if(!m_isDead) {
				Debug.Log("Win");
				SceneManager.LoadScene("Win");
			} else {
				Debug.Log("Lose");
				SceneManager.LoadScene("Lose");
			}
		}
	}
}

