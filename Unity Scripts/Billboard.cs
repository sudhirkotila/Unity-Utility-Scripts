﻿using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
	public Camera m_Camera;
	
	void Update()
	{
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.down);
	}
}