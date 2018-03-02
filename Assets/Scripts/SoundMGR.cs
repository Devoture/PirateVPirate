using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMGR : MonoBehaviour {

	public AudioClip m_oceanSfx;
	public AudioClip m_seasgullSfx;
	public AudioClip m_menuClickSfk;
	public AudioClip m_hit1;
	public AudioClip m_hit2;
	public AudioClip m_hit3;
	public AudioClip m_blockHit;
	public AudioClip m_battleMusic;
	public AudioClip m_menuMusic;
	public AudioSource m_backgroundeffects;
	public AudioSource m_PlayerSource;

	private int m_randnum;
	public static SoundMGR Instance { get { return m_instance; } }
	private static SoundMGR m_instance = null;
	
	void Start() {
		if(m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return; 
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	public void SwordBlock() {
		m_PlayerSource.PlayOneShot(m_blockHit);
	}
	
	public void MenuPress() {
		m_backgroundeffects.PlayOneShot(m_menuClickSfk);
	}	
}
