using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuQuitEvent : MonoBehaviour {

	private bool m_Quitting;
	public SoundMGR m_soundMgr;

	public void Update() {
		if(!m_soundMgr.m_backgroundeffects.isPlaying && m_Quitting) {
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}
	}

	public void OnMouseDown() {
		m_soundMgr.MenuPress();
		m_Quitting = true;
	}
}
