using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnableNetworkScripts : NetworkBehaviour {

	public Canvas m_playerHUD;
	public Transform m_head;

	void Start() {
		if(isLocalPlayer) {
			GetComponent<Health>().enabled = true;
			GetComponent<CharacterMovement>().enabled = true;
			this.gameObject.tag = "Player";
			Camera.main.transform.GetComponent<CameraController>().m_head = m_head;
			Camera.main.transform.parent = m_head.transform;
			Camera.main.transform.GetComponent<CameraController>().m_target = this.gameObject.transform;
		}
		GameManager.Instance.AddPlayer(gameObject);
	}

	public void SetupHUD() {
		if(isServer) {
			m_playerHUD.gameObject.SetActive(true);
		} else {
			m_playerHUD.gameObject.SetActive(false);
		}
	}
}
