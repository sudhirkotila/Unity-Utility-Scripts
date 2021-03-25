using UnityEngine;
using System.Collections;

public class Accelrometer_Demo : MonoBehaviour
{

	public GameObject ball;
	public Vector3 dir;

	// Update is called once per frame
	void Update ()
	{

		ball.transform.Translate (Input.acceleration.x * Time.deltaTime * 20f,0, 0);



		// Ball Rotation As Per Accelerometer
		dir.y = Input.acceleration.y;
		
		if (dir.y > 0.2f) {
			ball.transform.Rotate (Vector3.left * (100 * Time.deltaTime));
		} else if (dir.y < -0.2f) {
			ball.transform.Rotate (-Vector3.left * (100 * Time.deltaTime));
		}
	}
}
