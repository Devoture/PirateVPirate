using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;

    [SyncVar (hook = "UpdateHealth")]
    public int currHealth = maxHealth;

    public void TakeDamage(int amount) {
    	if (isServer) {
        	currHealth -= amount;
    	} else {
			// GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
        	CmdTakeDamage (amount);
    	}
	}

	[Command]
	void CmdTakeDamage(int amount) {
		Debug.Log("Server: cmd take damage");
		TakeDamage(amount);
	}

	void UpdateHealth(int health) {
		currHealth = health;
	}
}