﻿using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;

	}

	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

		transform.GetChild(0).gameObject.SetActive (true);

	}

	void OnMouseUp()
	{
		transform.GetChild(0).gameObject.SetActive (false);
	}

	void OnMouseEnter()
	{

	}

	void OnMouseExit()
	{

	}



}
