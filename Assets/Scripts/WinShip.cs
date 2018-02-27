using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinShip : MonoBehaviour {

public float speed = 1.0f;
public float amplitude = 0.5f;
public float midpoint = -0.3f;
public float tempVal;
private Vector3 tempPos;

void Start () 
     {
         tempVal = transform.position.y;
     }
 
	void Update () {
		tempPos.z = transform.position.z;
         tempPos.x = transform.position.x;     
         tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time) + midpoint;
         transform.position = tempPos;
		 transform.Translate(new Vector3(0,0,1)*4*Time.deltaTime);
	}
}
