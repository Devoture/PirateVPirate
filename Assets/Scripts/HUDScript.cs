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

	public void UpdateHUD(GameObject player, int health) {
		if(player.name == "Pirate1") {
			//int health = player.GetComponent<Health>().GetCurrentHealth();
			Debug.Log(player.GetComponent<Health>().GetCurrentHealth());
			m_leftHud.fillAmount = (float)health / (float)m_maxHealth;
		}

		if(player.name == "Pirate2") {
			//int health = player.GetComponent<Health>().GetCurrentHealth();
			Debug.Log(player.GetComponent<Health>().GetCurrentHealth());
			m_rightHud.fillAmount = (float)health / (float)m_maxHealth;
		}
	}
}
