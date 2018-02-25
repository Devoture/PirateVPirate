using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMGR : MonoBehaviour {
	public AudioClip m_oceanSfx;
	public static SoundMGR Instance { get { return m_instance; } }
	private static SoundMGR m_instance = null;
	// Use this for initialization
	void Start () {
		if(m_instance != null && m_instance != this) {
			Destroy(this.gameObject);
			return; 
		} else {
			m_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	
}
