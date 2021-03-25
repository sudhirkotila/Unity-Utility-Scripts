using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShakingMenuIteams : MonoBehaviour
{

	public List<GameObject> shakingObjectsList = new List<GameObject> ();

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
		int rndNum = Random.Range (0, shakingObjectsList.Count);
		GameObject animatedObj = shakingObjectsList [rndNum];
		iTween.ShakeRotation (animatedObj, new Vector3 (shakingXRotationValue, shakingYRotationValue, shakingZRotationValue), shakingTimeInterval);
	}
}
