using UnityEngine;
using System.Collections;

public class PinchZoom : MonoBehaviour 
{
	public float minDist = 2.0f;
	public float maxDist = 5.0f;
	public Transform projectile;
	public float speed;
	private Vector3 moveVec;
	private float startZ;
	private float actualDist;
	private Vector2 dragStartPos;
	
	void Start () 
	{        
		startZ = projectile.position.z;
	}
	
	void Update () 
	{
		//This section for move the camera position only limited values . 
		// You can Change the values for your requirements.
		//Here the camera will move with in your required portion on the screen.
		
//		if(projectile.position.z >= 100)
//		{            
//			transform.position = transform.position + new Vector3(0.0f,0.0f,-10.0f);
//		}
//		else if(projectile.position.z <= -150)
//		{
//			transform.position = transform.position + new Vector3(0.0f,0.0f,10.0f);
//		}
//		
//		if(projectile.position.y >= 140)
//		{
//			transform.position = transform.position + new Vector3(0.0f,-10.0f,0.0f);
//		}
//		else if(projectile.position.y <= -50)
//		{
//			transform.position = transform.position + new Vector3(0.0f,10.0f,0.0f);
//		}
//		
//		if(projectile.position.x >= 420)
//		{
//			transform.position = transform.position + new Vector3(-5.0f,0.0f,0.0f);
//		}
//		else if(projectile.position.x <= 85)
//		{
//			transform.position = transform.position + new Vector3(5.0f,0.0f,0.0f);
//		}
		
		// This Section For to move camera according to your swipe on screen.        
		if (Input.touchCount == 1 ) 
		{                
			Touch touch = Input.GetTouch(0);
			switch (touch.phase) 
			{
			case TouchPhase.Began:
				dragStartPos = touch.position;
				moveVec = Vector2.zero;
				break;
				
			case TouchPhase.Moved:
				Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
				pos.z = startZ;
				projectile.position = Camera.main.ScreenToWorldPoint(touch.position);
				//here i gave condition to move camera with in required position 
				if(projectile.position.z >= -150 && projectile.position.z <= 100)
				{
					moveVec =-(touch.position - dragStartPos) * speed;
				}
				break;
				
			case TouchPhase.Ended:
				dragStartPos = touch.position;
				moveVec = Vector2.zero;
				break;
			}
			projectile.Translate(moveVec * Time.deltaTime*-10);
			Vector3 val = moveVec * Time.deltaTime;
		}
		
		//This section for pinch Zooming on screen.        
		if (Input.touchCount == 2) 
		{
			Touch touch = Input.GetTouch(0);
			Touch touch1 = Input.GetTouch(1);
			if (touch.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved) 
			{
				Vector2 curDist = touch.position - touch1.position;
				Vector2 prevDist = (touch.position - touch.deltaPosition) - (touch1.position - touch1.deltaPosition);
				float delta = curDist.magnitude - prevDist.magnitude;
				Camera.main.transform.Translate(0,0,delta * .5f);
			}
		}


	}


}