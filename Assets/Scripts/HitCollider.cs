using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {

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
		if(this.name == "Pirate1") {
			if(other.name == "Sword" && !other.transform.root.GetComponent<HitCollider>().m_hasDealtDamage) {
				if(GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
					m_swordAudSrc.PlayOneShot(m_clash1);
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks++;
					GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
				} 
				if(GetComponent<CharacterMovement>().m_numOfBlockedAttacks > 3) {
					GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
					GetComponent<CharacterMovement>().m_animController.SetBool("isBlocking", false);
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
				if(!GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
					m_healthScript.CmdTakeDamage(10);
					Debug.Log(m_healthScript.GetCurrentHealth());
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
			}
		} else if (this.name == "Pirate2") {
			if(other.name == "Sword" && !other.transform.root.GetComponent<HitCollider>().m_hasDealtDamage) {
				if(GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
					m_swordAudSrc.PlayOneShot(m_clash1);
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks++;
					GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
				} 
				if(GetComponent<CharacterMovement>().m_numOfBlockedAttacks > 3) {
					GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
					GetComponent<CharacterMovement>().m_animController.SetBool("isBlocking", false);
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
				if(!GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
					m_healthScript.CmdTakeDamage(10);
					Debug.Log(m_healthScript.GetCurrentHealth());
					GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
			}
		}	
		m_hasDealtDamage = true;
	}

		public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}

	public void SwipeSound(){
		m_randNum = Random.Range(1,3);
		if(m_randNum == 1){
			m_swordAudSrc.PlayOneShot(m_swipe1);
		}
		if(m_randNum == 2){
			m_swordAudSrc.PlayOneShot(m_swipe2);
		}
	}
	public void HurtSound(){
		m_randNum = Random.Range(1,4);
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
