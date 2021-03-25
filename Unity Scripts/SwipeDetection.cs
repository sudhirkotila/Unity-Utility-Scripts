using UnityEngine;
using System.Collections;

public class SwipeDetection : MonoBehaviour
{
	
		private Vector2 fp; // first finger position
		private Vector2 lp; // last finger position
		public Transform player; // Drag your player here
	
		void OnGUI ()
		{
		
				CheckMouseAsTouch (Event.current.type, Input.mousePosition);
		
		}
		//Mouse Swipe Detection . . .
		void CheckMouseAsTouch (EventType touch, Vector3 currentPosition)
		{
		
				//began
				if (touch.ToString () == "mouseDown") {
						fp = new Vector2 (currentPosition.x, currentPosition.y);
						lp = new Vector2 (currentPosition.x, currentPosition.y);
				}
		
				//moved
				if (touch.ToString () == "mouseDrag") {
						lp = new Vector2 (currentPosition.x, currentPosition.y);
				}
		
				//ended
				if (touch.ToString () == "mouseUp") {

						fp.y = Mathf.Clamp (0f, -90f, 90f);
						if ((fp.x - lp.x) > 30) { // left swipe
								player.Rotate (0, -90, 0);
								print ("Left Swipe Using Mouse...");
						} else if ((fp.x - lp.x) < -30) { // right swipe
								player.Rotate (0, 90, 0);
								print ("Right Swipe Using Mouse...");
						}
				}
		}

		// Touch Swipe Detection . . .
		void Update ()
		{
				foreach (Touch touch in Input.touches) {
						if (touch.phase == TouchPhase.Began) {
								fp = touch.position;
								lp = touch.position;
						}
						if (touch.phase == TouchPhase.Moved) {
								lp = touch.position;
						}
						if (touch.phase == TouchPhase.Ended) {
								if ((fp.x - lp.x) > 80) { // left swipe
										player.Rotate (0, -90, 0);
										print ("Left Swipe Using Touch...");
								} else if ((fp.x - lp.x) < -80) { // right swipe
										player.Rotate (0, 90, 0);
										print ("Right Swipe Using Touch...");
								} else if ((fp.y - lp.y) < -80) { // up swipe
										// add your jumping code here
								}
						}
				}
		}

}