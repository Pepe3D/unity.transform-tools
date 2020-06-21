using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : TransformToolBase {
		
	public float lookSpeed = 2f;
	public bool fixedRotation = false;
	public bool xAxisRotationBlocked = false;
	public bool yAxisRotationBlocked = false;
	public bool zAxisRotationBlocked = false;
	public bool invertRotation = false;

	protected override void GameLoop() 
	{
		if (originT == null || targetT == null) return;

		Vector3 lookPos = targetT.position - originT.position;

		if (xAxisRotationBlocked) lookPos = new Vector3(0f, lookPos.y, lookPos.z);
		if (yAxisRotationBlocked) lookPos = new Vector3(lookPos.x, 0f, lookPos.z);
		if (zAxisRotationBlocked) lookPos = new Vector3(lookPos.x, lookPos.y, 0f);
	
		if (invertRotation) lookPos = -lookPos;

		if (fixedRotation) originT.rotation = Quaternion.LookRotation (lookPos);
		else originT.rotation = Quaternion.Lerp (originT.rotation, Quaternion.LookRotation (lookPos), lookSpeed * Time.deltaTime);
	}

	private void OnDrawGizmos() {

		if (origin == null || target == null) return;
		originT = origin.GetComponent<Transform>();
		targetT = target.GetComponent<Transform>();
		if (originT == null || targetT == null) return;

		Gizmos.color = Color.red;
		Vector3 lookPos = targetT.position - originT.position;
		if (xAxisRotationBlocked) lookPos = new Vector3(0f, lookPos.y, lookPos.z);
		if (yAxisRotationBlocked) lookPos = new Vector3(lookPos.x, 0f, lookPos.z);
		if (zAxisRotationBlocked) lookPos = new Vector3(lookPos.x, lookPos.y, 0f);

		if (invertRotation) lookPos = -lookPos;

		Gizmos.DrawLine(this.transform.position, this.transform.position + (lookPos * 1f));
	}
}
