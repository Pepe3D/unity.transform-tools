using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : TransformToolBase {

	public float rotateAroundSpeed = 2f;
	public Vector3 rotateAroundAxis;

	protected override void GameLoop() 
	{
		if (originT == null || targetT == null) return;

		originT.RotateAround(targetT.position, rotateAroundAxis, rotateAroundSpeed);
	}
}
