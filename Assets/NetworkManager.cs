using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager_Custom : NetworkManager {

	public void StartupHost() {
		SetPort();
		NetworkManager.singleton.StartHost();
	}
	public void JoinGame() {
		SetIPAdress();
		Setport();
		NetworkManager.singleton.StartClient();
	}
	void SetIPAdress() {
		string ipAdress = GameObject.Find("InputFieldAdress").transform.Find("text").GetComponnet<text>().text;
		NetworkManager.singleton.networkAdress = ipAdress;
	}
	void SetPort() {
		NetworkManager.singleton.networkPort = 7777;
	}
}
