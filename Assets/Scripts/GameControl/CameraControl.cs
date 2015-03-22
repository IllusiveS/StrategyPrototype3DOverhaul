using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
		
		
		float mousePosX = Input.mousePosition.x; 
		float mousePosY = Input.mousePosition.y; 
		int scrollDistance = 5; 
		float scrollSpeed = 2 * 4.5f;
		Vector3 aPosition = new Vector3(0, 0, 0);
		float ScrollAmount = scrollSpeed * Time.deltaTime;
		const float orthographicSizeMin = 15f;
		const float orthographicSizeMax = 256f;

		//Keyboard controls 
		if ((Input.GetKey(KeyCode.UpArrow)) && (transform.position.z < 240))
		{ 
			transform.Translate (0,0,ScrollAmount, Space.World); ; 
		} 
		if ((Input.GetKey(KeyCode.DownArrow)) && (transform.position.z > -240))
		{ 
			transform.Translate (0,0,-ScrollAmount, Space.World);
		}
		if ((Input.GetKey(KeyCode.LeftArrow)) && (transform.position.x > -240))
		{ 
			transform.Translate (-ScrollAmount,0,0, Space.World);  
		} 
		if ((Input.GetKey(KeyCode.RightArrow)) && (transform.position.x < 240))
		{ 
			transform.Translate (ScrollAmount,0,0, Space.World); 
		}
		
		//Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax );
	}
}
