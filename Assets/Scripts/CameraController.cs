using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform m_target;
	public float m_distance = 12.0f;
	public float m_xSpeed = 200.0f;
	public float m_ySpeed = 200.0f;
	public float m_zoomSpeed = 500.0f;
	public float m_minDistance = 2.5f;
	public float m_maxDistance = 20.0f;
	public float m_maxXDeg = 60.0f;
	public float m_autoRotationSpeed = 10.0f;
	public Transform m_head;
	
	private float m_xDeg = 0.0f;
	private float m_yDeg = 0.0f;
	private float m_rotateSpeed = 5.0f;
	private bool m_alwaysRotatetoRearofTarget = true;
	private bool m_rotateBehind = false;
	

	void Start() {
		Vector3 angles = transform.eulerAngles;
		m_xDeg = angles.x;
		m_yDeg = angles.y;
	}		
	
	void LateUpdate() {
		//if you havent already rotated behind the player and you have a target then rotate behind target
		if(!m_rotateBehind && m_head != null) {
			RotateBehindTarget();
		}

		if(m_target != null && m_head != null) {
			//Gets the mouse position
			m_xDeg += Input.GetAxis("Mouse X") * m_rotateSpeed;
			m_yDeg -= Input.GetAxis("Mouse Y") * m_rotateSpeed;
			float horizontal = Input.GetAxis("Mouse X") * m_rotateSpeed;
			
			//sets the amount the camera can move above and below the player
			if(m_yDeg >= m_maxXDeg) {
				m_yDeg = m_maxXDeg;
			} else if (m_yDeg <= -m_maxXDeg) {
				m_yDeg = -m_maxXDeg;
			}

			//Rotates the camera to mouse position
			Quaternion rotation = Quaternion.Euler(m_yDeg, m_xDeg, 0);
			Vector3 position =  m_head.position;
			transform.rotation = rotation;
			transform.position = new Vector3(position.x, position.y, position.z);
			

			//rotates the player to camera's rotation
			m_head.transform.root.Rotate(0, horizontal, 0);
		}
	}

	private void RotateBehindTarget(){
        float targetRotationAngle = m_target.eulerAngles.y;
        float currentRotationAngle = transform.eulerAngles.y;
        m_xDeg = Mathf.LerpAngle(currentRotationAngle, targetRotationAngle, m_autoRotationSpeed * Time.deltaTime);
		m_rotateBehind = true;
    }
}