using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour {
private float speed = 10.0f;
private float amplitude = 20f;
private float y0;
private float newY;

	// Use this for initialization
	void Start () {
		 y0 = transform.position.y;
		
	}
	
	// Update is called once per frame
	void Update () {
		newY=y0+amplitude*Mathf.Sin(speed*Time.time);
		//transform.position.y =newY;
	}
}
