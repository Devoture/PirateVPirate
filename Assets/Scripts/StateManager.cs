using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {
public GameObject m_maincam;
private GameObject m_activeState;
public GameObject[] m_gameStates;

	// Use this for initialization
	void Start () {
		int numStates = m_gameStates.Length;

		for(int i = 0;i < numStates; i++){
			m_gameStates[i].SetActive(false);
		}

		m_activeState = m_gameStates[0];
		m_activeState.SetActive(true);
	}
	public void Exit(){
		 #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
	}

}
