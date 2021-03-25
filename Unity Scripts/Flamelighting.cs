using UnityEngine;
using System.Collections;

public class Flamelighting : MonoBehaviour
{

	public float minValue = 2.3f;
	public float maxValue = 4.2f;
	public float timeFactor = 0.1f;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine ("StartFlameLight");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	IEnumerator StartFlameLight ()
	{
		yield return new WaitForSeconds (timeFactor);
		transform.gameObject.GetComponent<Light> ().intensity = Random.Range (minValue, maxValue);
		StartCoroutine ("StartFlameLight");

	}

}
