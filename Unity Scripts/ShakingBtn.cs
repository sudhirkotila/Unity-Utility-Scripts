using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShakingBtn : MonoBehaviour
{
	public int shakingXRotationValue;
	public int shakingYRotationValue;
	public int shakingZRotationValue;

	public float shakingTimeInterval;


	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("ShakingAnimation", 1, 2);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private void ShakingAnimation ()
	{
		iTween.ShakeRotation (this.gameObject, new Vector3 (shakingXRotationValue, shakingYRotationValue, shakingZRotationValue), shakingTimeInterval);
	}
}
