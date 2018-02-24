using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class  Networking : NetworkManager {

	public void StartupHost() {
		SetPort();
		NetworkManager.singleton.StartHost();
	}
	public void JoinGame() {
		SetIPAdress();
		SetPort();
		NetworkManager.singleton.StartClient();
	}
	void SetIPAdress() {
		string ipAdress = GameObject.Find("InputFieldAdress").transform.Find("text").GetComponent<Text>().text;
		NetworkManager.singleton.networkAddress = ipAdress;
	}
	void SetPort() {
		NetworkManager.singleton.networkPort = 7777;
	}
}
