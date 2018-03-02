using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get { return m_instance; } }
	public Text m_countDownText;
	public Text m_gameStartingIn;
	public Canvas m_lobbyCanvas;
	public bool m_gameStarted = false;
	public Canvas m_hud;
	public HUDScript m_hudScript;
	public Button m_readyButton;
	public List<GameObject> m_players = new List<GameObject>();

	private static GameManager m_instance;
	private bool m_canStartCoroutine = true;
	private int m_numPlayersActive = 0;
	private int m_countDown = 3;
	private int m_numReadyPlayers = 0;
	private GameObject m_host = null;
	private CursorLockMode m_wantedMode;

	public void AddPlayer(GameObject Player) {
		if (m_host == null) {
			m_host = Player;
		}
		if (!m_players.Contains(Player)) {
			m_players.Add(Player);
			m_numPlayersActive++;
			Player.name = "Pirate" + m_numPlayersActive;
		}
		m_gameStartingIn.text = m_numPlayersActive + "/2";
		m_countDownText.text = "Waiting for players...";
	}

	private void Awake() {
		m_instance = this;
		m_gameStartingIn.text = m_numPlayersActive + "/2";
	}

	void Update() {
		if(m_countDown >= 0 && m_numPlayersActive >= 2) {
			StartGame();
		}
	}

	void StartGame() {
		if(m_canStartCoroutine) {
			m_canStartCoroutine = false;
			StartCoroutine(CountDown());
		}
	}

	public void CheckGameOver() {
		m_numPlayersActive--;
		if(m_numPlayersActive <= 1) {
			for(int i = 0; i < m_players.Count; i++) {
				m_players[i].GetComponent<CharacterMovement>().GameOver();
			}
		}
	}

	IEnumerator CountDown() {
        yield return new WaitForSeconds(1);
		m_canStartCoroutine = true;
		if(m_countDown > 0) {
			m_gameStartingIn.text = "Game Starting In";
			m_countDownText.text = m_countDown.ToString();
			m_countDown--;
		} else {
			m_gameStarted = true;
			m_hud.gameObject.SetActive(true);
			m_gameStartingIn.gameObject.SetActive(false);
			m_countDownText.gameObject.SetActive(false);
			m_lobbyCanvas.gameObject.SetActive(false);
		}
    }
}
