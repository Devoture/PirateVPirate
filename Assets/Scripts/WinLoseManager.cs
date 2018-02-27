using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour {

	public void QuitGame() {
		#if UNITY_EDITOR
         	UnityEditor.EditorApplication.isPlaying = false;
     	#else
         	Application.Quit();
    	#endif
	}

	public void PlayAgain() {
		SceneManager.LoadScene("MainMenuScene");
		// TODO: maybe make reset function to reset all gamemanager variables
	}
}
