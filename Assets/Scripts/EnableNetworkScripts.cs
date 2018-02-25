using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnableNetworkScripts : NetworkBehaviour {

	public override void OnStartLocalPlayer() {
		Camera.main.GetComponent<CameraController>().enabled = true;
		GetComponent<CharacterMovement>().enabled = true;
	}
}
