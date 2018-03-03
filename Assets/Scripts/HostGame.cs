using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour {

	[SerializeField]
	private uint roomSize = 6;
	private string roomName;
	private NetworkManager networkManager;
	private string m_pirateName1;
	private string m_pirateName2;
	
	void Start() {
		networkManager = NetworkManager.singleton;
		if(networkManager.matchMaker == null) {
			networkManager.StartMatchMaker();
		}
	}

	public void SetRoomName(string _name) {
		roomName = _name;
		Debug.Log(_name);
	}

	public void SetPirateName(string name) {
		if(m_pirateName1 == null) {
			if(name == "") {
				m_pirateName1 = "Player 1";
			} else {
				m_pirateName1 = name;
			}
			Debug.Log("Pirate1: " + m_pirateName1);
		} else {
			if(name == "") {
				m_pirateName2 = "Player 2";
			} else {
				m_pirateName2 = name;
			}
			Debug.Log("Pirate1: " + m_pirateName2);
		}
	}
	
	public void CreateRoom() {
		if (roomName != "" && roomName != null) {
			Debug.Log("Creating Room: " + roomName + "with room for" + roomSize + "players.");
			networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
		}
	}
}
