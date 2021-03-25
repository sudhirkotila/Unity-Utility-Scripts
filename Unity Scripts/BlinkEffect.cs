using UnityEngine;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
	#region PRIVATE_VARS
		//chek if Object is blink or not
		public static bool isBlink;
		//Time For Blink
		private float blinkTime=0.2f;
	#endregion

	#region UNITY_CALLBACKS
		// Use this for initialization
		void Start ()
		{
			StartCoroutine ("BlinkObject");
		}
	
		// Update is called once per frame
		void Update ()
		{
		}
	#endregion
	#region PRIVATE_METHODS
	/// <summary>
	/// Blinks the Object.
	/// </summary>
	/// <returns>The Object.</returns>
		IEnumerator BlinkObject ()
		{
				yield return new WaitForSeconds(blinkTime);
				if(!isBlink)
				{
					isBlink=true;
					gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1,0);
					StartCoroutine("BlinkObject");
				}
				else
				{
					isBlink=false;
					gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1,1);
					StartCoroutine("BlinkObject");
				} 
		
		}
	#endregion
}
