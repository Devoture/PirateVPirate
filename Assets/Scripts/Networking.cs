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
	void OnLevelWasLoaded(int level) {
		if(level == 0) {
			SetUpMenuSceneButtons();
		} else {
			SetUpOtherSceneButton();
		}

	}
	void SetUpMenuSceneButtons() {
		GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartupHost);

		GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
	}
	void SetUpOtherSceneButton() {
		GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
	}
}
