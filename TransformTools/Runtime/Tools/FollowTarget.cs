using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public GameObject origin;
	public GameObject target;
	public Vector3 distanceToTarget;
	public float followSpeed = 2f;
	public bool fixedPosition = false;

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
