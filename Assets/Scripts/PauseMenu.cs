using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private NetworkManager m_networkManager;

    void Start() {
        m_networkManager = NetworkManager.singleton;
    }

    public void LeaveRoom() {
        GameManager.Instance.CheckGameOver();
        MatchInfo matchInfo = m_networkManager.matchInfo;
        m_networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, m_networkManager.OnDropConnection);
        m_networkManager.StopHost();
        SceneManager.LoadScene("main");
    }
}