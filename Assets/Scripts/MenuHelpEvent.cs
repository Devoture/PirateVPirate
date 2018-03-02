using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHelpEvent : MonoBehaviour {

	public MenuStates m_menuStateMgr;

	public void OnMouseDown() {
		m_menuStateMgr.Help();
	}
}
