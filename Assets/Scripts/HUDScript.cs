using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {

	public Image m_leftHud;
	public Image m_rightHud;

	private GameObject m_pirate1;
	private GameObject m_pirate2;

	private int m_maxHealth = 100;

	public void UpdateHUD(GameObject player) {
		if(player.name == "Pirate1") {
			int pirate1Health = player.GetComponent<Health>().GetCurrentHealth();
			m_leftHud.fillAmount = (float)pirate1Health / (float)m_maxHealth;
			Debug.Log(player.GetComponent<Health>().GetCurrentHealth());
		}

		if(player.name == "Pirate2") {
			int pirate2Health = player.GetComponent<Health>().GetCurrentHealth();
			m_rightHud.fillAmount = (float)pirate2Health  / (float)m_maxHealth;
			Debug.Log(player.GetComponent<Health>().GetCurrentHealth());
		}
	}

	public void Pirate1UpdateHUD(int health) {
		m_leftHud.fillAmount = (float)health / (float)m_maxHealth;
		//Debug.Log(player.GetComponent<Health>().GetCurrentHealth());
	}
}
