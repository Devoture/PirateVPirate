using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayEvent : MonoBehaviour {
	public StateManager m_stateMgr;
	public void OnMouseDown(){
		m_stateMgr.PlayGame();
	}
	
}
