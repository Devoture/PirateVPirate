using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStates : MonoBehaviour {

	public GameObject m_helpCanvas;
	public GameObject m_ships;
	
	void Start() {
		CloseHelp();
	}

	public void Help() {
		m_helpCanvas.SetActive(true);
		m_ships.SetActive(false);
	}

	public void CloseHelp() {
		m_helpCanvas.SetActive(false);
		m_ships.SetActive(true);
	}
}
