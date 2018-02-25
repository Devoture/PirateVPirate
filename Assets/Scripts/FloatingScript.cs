using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour {
private float speed = 1.0f;
private float amplitude = 0.5f;
private float midpoint = -0.3f;
private float tempVal;
private Vector3 tempPos;

void Start () 
     {
         tempVal = transform.position.y;
     }
 
     void Update () 
     {        
         tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time) + midpoint;
         transform.position = tempPos;
     }
}
