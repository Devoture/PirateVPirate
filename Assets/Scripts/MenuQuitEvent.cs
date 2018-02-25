using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuQuitEvent : MonoBehaviour {

	public StateManager m_stateMgr;
	public void OnMouseDown(){
		#if UNITY_EDITOR
         	UnityEditor.EditorApplication.isPlaying = false;
     	#else
         	Application.Quit();
    	#endif
	}
}
