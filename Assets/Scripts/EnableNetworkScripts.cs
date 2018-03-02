using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnableNetworkScripts : NetworkBehaviour {

	public Transform m_head;
	public GameObject m_sword;

	void Start() {
		if(isLocalPlayer) {
			GetComponent<Health>().enabled = true;
			GetComponent<CharacterMovement>().enabled = true;
			this.gameObject.tag = "Player";
			this.m_sword.tag = "Sword";
			Camera.main.transform.GetComponent<CameraController>().m_head = m_head;
			Camera.main.transform.parent = m_head.transform;
		}
		
		GameManager.Instance.AddPlayer(gameObject);
		GetComponent<Health>().m_hudScript = GameManager.Instance.m_hudScript;
	}
}
