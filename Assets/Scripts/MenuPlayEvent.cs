using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPlayEvent : MonoBehaviour {
	public StateManager m_stateMgr;
	public void OnMouseDown(){
		SceneManager.LoadScene("Menu");
	}
	
}
