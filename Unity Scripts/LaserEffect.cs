﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]

public class LaserEffect : MonoBehaviour 
{
	Vector2 mouse;
	RaycastHit hit;
	float range = 100.0f;
	LineRenderer line;
	public Material lineMaterial;
	
	void Start()
	{
		line = GetComponent<LineRenderer>();
		line.SetVertexCount(2);
		line.renderer.material = lineMaterial;
		line.SetWidth(0.1f, 0.25f);
	}
	
	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, range))
		{
			if(Input.GetMouseButton(0))
			{
				line.enabled = true;
				line.SetPosition(0, transform.position);
				line.SetPosition(1, hit.point + hit.normal);
			}
			else
				line.enabled = false;
		}
		
	}
}
