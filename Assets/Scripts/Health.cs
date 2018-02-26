using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;
	public Transform m_piratePrefab;

    [SyncVar (hook = "UpdateHealth")]
    public int currHealth = maxHealth;

    public void TakeDamage(int amount) {
    	if (isServer) {
        	currHealth -= amount;
    	} else {
			m_piratePrefab.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
        	CmdTakeDamage (amount);
    	}
	}

	[Command]
	void CmdTakeDamage(int amount) {
		TakeDamage(amount);
	}

	void UpdateHealth(int health) {
		currHealth = health;
	}
}