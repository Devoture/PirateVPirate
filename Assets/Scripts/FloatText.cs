using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour {
    private float speed = 1.0f;
    private float amplitude = 0.5f;
    private float midpoint = -0.3f;
    private float tempVal;
    private float tempy;

    void Start() {
        tempVal = transform.position.y;
    }
 
    void Update() {        
        tempy = tempVal + amplitude * Mathf.Sin(speed * Time.time) + midpoint;
    }
}
