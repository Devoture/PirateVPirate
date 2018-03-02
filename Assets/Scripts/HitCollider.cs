using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HitCollider : NetworkBehaviour {

	public bool m_hasDealtDamage;
	public AudioClip m_hit1;
	public AudioClip m_hit2;
	public AudioClip m_hit3;
	public AudioClip m_clash1;
	public AudioClip m_swipe1;
	public AudioClip m_swipe2;
	public AudioSource m_swordAudSrc;
	private float m_damage = 10.0f;
	private Animator m_animController;
	private Health m_healthScript;
	private int m_randNum;

	// Use this for initialization
	void Start () {
		m_healthScript = GetComponent<Health>();
		m_animController = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(this.tag == "Player") {
			if(other.tag == "EnemySword" && !other.transform.root.GetComponent<HitCollider>().m_hasDealtDamage) {
				CharacterMovement hitMovement = other.transform.root.GetComponent<CharacterMovement>();
				if(hitMovement != null ) {
					if(hitMovement.m_animController.GetBool("isBlocking")) {
						m_swordAudSrc.PlayOneShot(m_clash1);
						hitMovement.m_numOfBlockedAttacks++;
						hitMovement.m_animController.SetBool("blockedAttack", true);
					} 
					if(hitMovement.m_numOfBlockedAttacks > 3) {
						hitMovement.m_animController.SetBool("blockedAttack", true);
						hitMovement.m_animController.SetBool("isBlocking", false);
						hitMovement.m_numOfBlockedAttacks = 0;
					}
					if(!hitMovement.m_animController.GetBool("isBlocking")) {
						HurtSound();
						if(isLocalPlayer) {
							m_healthScript.CmdTakeDamage(10);
							Debug.Log(m_healthScript.GetCurrentHealth());
						}
						hitMovement.m_numOfBlockedAttacks = 0;
					}
					m_hasDealtDamage = true;
				}
			}
		}	
	}

		public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}

	public void HurtSound(){
		m_randNum = Random.Range(1, 4);
		if(m_randNum == 1){
			m_swordAudSrc.PlayOneShot(m_hit1);
		}
		if(m_randNum == 2){
			m_swordAudSrc.PlayOneShot(m_hit2);
		}
		if(m_randNum == 3){
			m_swordAudSrc.PlayOneShot(m_hit3);
		}
	}
}
