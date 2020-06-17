using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour {

	public GameObject origin;
	public GameObject target;
	public float rotateAroundSpeed = 2f;
	public Vector3 rotateAroundAxis;
	private Transform originRotateAroundT;
	private Transform targetToRotateAroundT;
	public bool inLateUpdate = false;

	private Transform originT;
	private Transform targetT;

	void OnEnable() 
	{
		if (origin != null) originT = origin.GetComponent<Transform>();
		if (target != null) targetT = target.GetComponent<Transform>();
	}

	public void GameLoop() 
	{
		if (originT == null || targetT == null) return;

		originT.RotateAround(targetT.position, rotateAroundAxis, rotateAroundSpeed);
	}

	[ContextMenu("SetThisGameObjectAsOrigin")]
	public void SetThisGameObjectAsOrigin() {
		origin = this.gameObject;
	}

	[ContextMenu("CreateTargetObject")]
	public void CreateTargetObject() {
		target = new GameObject("TargetOf_" + this.gameObject.name);
		target.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward;
	}

	void Update() { 		if (!inLateUpdate) GameLoop(); }
	void LateUpdate() { 	if (inLateUpdate) GameLoop(); }
}
