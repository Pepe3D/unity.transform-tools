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

	[Header("Update")]
	public bool inLateUpdate = false;
	public bool inFixedUpdate = false;

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

	void Update () { 		if (!inLateUpdate && !inFixedUpdate) GameLoop (); }
	void LateUpdate () { 	if (inLateUpdate && !inFixedUpdate) GameLoop (); }
	void FixedUpdate () {	if (inFixedUpdate && !inLateUpdate) GameLoop (); }
}
