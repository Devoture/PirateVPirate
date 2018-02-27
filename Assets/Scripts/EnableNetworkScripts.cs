using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnableNetworkScripts : NetworkBehaviour {

	public Canvas m_playerHUD;

	void Start() {
		if(isLocalPlayer) {
			m_playerHUD.gameObject.SetActive(true);
			GetComponent<Health>().enabled = true;
			GetComponent<CharacterMovement>().enabled = true;
			this.gameObject.tag = "Player";
			GameManager.Instance.AddPlayer(this.gameObject);
		}
	}
}
