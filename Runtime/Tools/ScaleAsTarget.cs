using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAsTarget : MonoBehaviour {

	public GameObject origin;
	public GameObject target;
	
	public float followSpeed = 2f;
	public bool fixedPosition = false;
	private Vector3 previousScale;
	public bool inLateUpdate = false;

	private Transform originT;
	private Transform targetT;

	void OnEnable() 
	{
		if (origin != null) originT = origin.GetComponent<Transform>();
		if (target != null) targetT = target.GetComponent<Transform>();
		
		previousScale = targetT.localScale;
	}

	public void GameLoop() {
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
