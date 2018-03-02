using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossShip : MonoBehaviour {

	public bool m_stillsinking;

	public void Start() {
		m_stillsinking = true;
	}

	void Update() {
		ShipWreck();
	}
	
	public void ShipWreck() {
		if(m_stillsinking) {
			transform.Rotate(Vector3.right * 3 * Time.deltaTime);
			transform.Translate(Vector3.down * Time.deltaTime);
		}
		if(transform.rotation.x >= 0.5) {
			m_stillsinking = false;
		} 
	}
}
