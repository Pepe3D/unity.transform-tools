using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : TransformToolBase {

	public Vector3 distanceToTarget;
	public float followSpeed = 2f;
	public bool fixedPosition = false;

	protected override void GameLoop() 
	{
		if (originT == null || targetT == null) return;

		if (fixedPosition) {
			originT.position = targetT.position 
				+ targetT.right * distanceToTarget.x
				+ targetT.up * distanceToTarget.y
				+ targetT.forward * distanceToTarget.z;
		}
		else {
			originT.position = Vector3.Lerp(originT.position, targetT.position 
				+ targetT.right * distanceToTarget.x
				+ targetT.up * distanceToTarget.y
				+ targetT.forward * distanceToTarget.z, followSpeed * Time.deltaTime);
		}
	}
}
