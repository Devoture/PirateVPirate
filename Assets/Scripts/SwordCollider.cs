using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SwordCollider : MonoBehaviour {

	public bool m_hasDealtDamage;

	private float m_damage = 10.0f;
	private Animator m_animController;
	private Health m_healthScript;
	public SoundMGR m_soundmgr;

	public AudioSource m_swordsource;
	public AudioClip m_hit1;
	public AudioClip m_hit2;
	public AudioClip m_hit3;

	public AudioClip m_clashhit1;
	public AudioClip m_clashhit2;
	public int m_randnum;
	void Start () {
		m_animController = transform.root.GetComponent<Animator>();
		m_healthScript = transform.root.GetComponent<Health>();
	}

	void OnTriggerEnter(Collider other) {
		var hit = other.gameObject;
		var hitPlayer = hit.GetComponent<Health>();
		if(other.tag == "Enemy" && !m_hasDealtDamage) {
			if(other.GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
				other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks++;
				other.GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
			} 
			if(hitPlayer != null) {
				if(other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks > 3) {
					other.GetComponent<CharacterMovement>().m_animController.SetBool("blockedAttack", true);
					other.GetComponent<CharacterMovement>().m_animController.SetBool("isBlocking", false);
					other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
				if(!other.GetComponent<CharacterMovement>().m_animController.GetBool("isBlocking")) {
					PlayerHit();
					hitPlayer.TakeDamage(10);
					Debug.Log("Take damage");
					Debug.Log(hitPlayer.GetCurrentHealth());
					other.GetComponent<CharacterMovement>().m_numOfBlockedAttacks = 0;
				}
			}
			m_hasDealtDamage = true;
		}
	}
	public void PlayerHit(){
		m_randnum = Random.Range(1,3);
		if(m_randnum == 1){
			m_swordsource.PlayOneShot(m_hit1);
		}
		if(m_randnum == 2){
			m_swordsource.PlayOneShot(m_hit2);
		}
		if(m_randnum == 3){
			m_swordsource.PlayOneShot(m_hit3);
		}
		
	}

	public void blockhit(){
		m_randnum = Random.Range(1,2);

		if(m_randnum == 1){
			m_swordsource.PlayOneShot(m_clashhit1);
		}
		if(m_randnum == 2){
			m_swordsource.PlayOneShot(m_clashhit2);
		}
	}
	public void ResetBlock() {
		m_animController.SetBool("isBlocking", false);
		m_hasDealtDamage = false;
	}
}
