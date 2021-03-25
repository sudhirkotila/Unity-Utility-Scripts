using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{

	public float scrollSpeed;
	private Vector2 savedOffset;

	void Start ()
	{
		savedOffset = transform.GetComponent<Renderer> ().sharedMaterial.GetTextureOffset ("_MainTex");
	}

	void Update ()
	{
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, savedOffset.y);
		transform.GetComponent<Renderer> ().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

	void OnDisable ()
	{
		transform.GetComponent<Renderer> ().sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}