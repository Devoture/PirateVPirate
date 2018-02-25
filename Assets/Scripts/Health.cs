using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {
	
    public const int m_maxHealth = 100;
	public Image m_healthHUD;

	[SyncVar(hook = "UpdateHUD")]
	public int m_currHealth = m_maxHealth;

	public void TakeDamage(int damage) {
		if(!Network.isServer) {
			CmdDamagePlayer(damage);
			Debug.Log("CMD: " + m_currHealth);
		}
		else {
			RpcDamagePlayer(damage);
			Debug.Log("LOCAL: " + m_currHealth);
		}
	}

	[Command]
	void CmdDamagePlayer(int damage)
	{
		RpcDamagePlayer(damage);
	}
	
	[ClientRpc]
	void RpcDamagePlayer(int damage)
	{
		m_currHealth -= damage;
		if(m_currHealth <= 0) {
			m_currHealth = 0;
			Died();
		}
	}

	public int GetHealth() {
		return m_currHealth;
	}

	void Died() {
		// dying stuff here
		Destroy(this.gameObject);
	}

	void UpdateHUD(int m_currHealth) {
		m_healthHUD.fillAmount = (float)m_currHealth / (float)m_maxHealth;
	}
}