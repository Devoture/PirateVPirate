using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnableNetworkScripts : NetworkBehaviour {

	void Start() {
		if(isLocalPlayer) {
			GetComponent<CharacterMovement>().enabled = true;
			this.gameObject.tag = "Player";
			GameManager.Instance.AddPlayer(this.gameObject);
		}
	}
}
