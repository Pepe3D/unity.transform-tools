using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAsTarget : TransformToolBase {

	public float followSpeed = 2f;
	public bool fixedPosition = false;
	private Vector3 previousScale;

	protected override void OnEnable() 
	{	
		base.OnEnable();
		previousScale = targetT.localScale;
	}

	protected override void GameLoop() {
		if (originT == null || targetT == null) return;

		Vector3 currentTargetLocalScale =  targetT.localScale;
		if (currentTargetLocalScale != previousScale) {
			Vector3 difference = currentTargetLocalScale - previousScale;
			Vector3 division = Vector3.Scale(difference, new Vector3(1f/previousScale.x, 1f/previousScale.y, 1f/previousScale.z));
			Vector3 multiplication = Vector3.Scale(division, originT.localScale);
			originT.localScale += multiplication;
			previousScale = currentTargetLocalScale;
		}
	}
}
