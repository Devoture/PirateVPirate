using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPlayEvent : MonoBehaviour {
	public SoundMGR m_SoundManager;
	public bool m_playing;

	void Update(){
		if(!m_SoundManager.m_backgroundeffects.isPlaying && m_playing){
			SceneManager.LoadScene("Menu");
		}
	}
	public void OnMouseDown(){
		m_SoundManager.MenuPress();
		m_playing = true;
	}
	
}
