using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour {

    public const int maxHealth = 100;
	private CharacterMovement m_charMovement;

    [SyncVar (hook = "UpdateHealth")]
    public int currHealth = maxHealth;

	void Start() {
		m_charMovement = GetComponent<CharacterMovement>();
	}

    public void TakeDamage(int amount) {
    	if (isServer) {
        	currHealth -= amount;
    	} else {
			m_charMovement.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
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