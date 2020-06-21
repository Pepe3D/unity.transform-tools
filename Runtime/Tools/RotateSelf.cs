using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : TransformToolBase 
{
	public float rotateSpeed = 2f;
	public Vector3 rotateAxis;
	public bool isRelativeToLocalAxis;
	
	protected override void GameLoop() {
		if (originT == null) return;

		if (isRelativeToLocalAxis) originT.rotation *= Quaternion.AngleAxis(rotateSpeed, rotateAxis); 	//Local axis
		else originT.rotation = Quaternion.AngleAxis(rotateSpeed, rotateAxis) * originT.rotation; 		//Global axis
	}
}
