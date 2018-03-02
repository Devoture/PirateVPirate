using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {

	public static StateManager Instance { get { return m_instance; } }
	public GameObject m_maincam;
	private GameObject m_activeState;
	public GameObject[] m_gameStates;
	public GameObject m_gameOptions;
	public GameObject m_HelpCanvas;

	private static StateManager m_instance;

	private void Awake() {
		m_instance = this;
	}
	
	void Start() {
		DisableOptionScreen();
		m_HelpCanvas.SetActive(false);
		m_activeState = m_gameStates[1];
		m_activeState.SetActive(true);
	}

	public void Exit() {
		#if UNITY_EDITOR
         	UnityEditor.EditorApplication.isPlaying = false;
     	#else
         	Application.Quit();
    	#endif
	}

	public void Menu() {
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[0];
		m_activeState.SetActive(true);
	}

	public void PlayGame() {
		m_activeState.SetActive(false);
		m_activeState = m_gameStates[1];
		m_activeState.SetActive(true);
	}

	public void EnableOptionScreen() {
		m_gameOptions.SetActive(true);
	}

	public void DisableOptionScreen() {
		m_gameOptions.SetActive(false);
	}

	public void EnableHelp() {
		DisableOptionScreen();
		m_HelpCanvas.SetActive(true);
	}

	public void DisableHelp() {
		EnableOptionScreen();
		m_HelpCanvas.SetActive(false);
	}
	
	public void DisableAll() {
		DisableOptionScreen();
		m_HelpCanvas.SetActive(false);
	}
}
