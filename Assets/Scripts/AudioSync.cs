using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSync : NetworkBehaviour {
	public AudioSource source;
	public AudioClip[] clips;
	
	public void PlaySound(int id){
		if(id >= 0 && id < clips.Length){
			CmdSendServerId(id);
		}
	}

	[Command]
	void CmdSendServerId(int id){
		RpcSendtoClient(id);
	}

	[ClientRpc]
	void RpcSendtoClient(int id){
		source.PlayOneShot(clips[id]);
	}

}
