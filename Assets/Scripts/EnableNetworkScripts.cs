using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnableNetworkScripts : NetworkBehaviour {

	public override void OnStartLocalPlayer() {
		GetComponent<CharacterMovement>().enabled = true;
		this.gameObject.tag = "Player";
	}
}
