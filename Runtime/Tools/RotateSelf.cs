using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {

	public GameObject origin;
	public float rotateSpeed = 2f;
	public Vector3 rotateAxis;
	public bool isRelativeToLocalAxis;
		
	[Header("Update")]
	public bool inLateUpdate = false;
	public bool inFixedUpdate = false;

	private Transform originT;
	
	void OnEnable() 
	{
		if (origin != null) originT = origin.GetComponent<Transform>();
	}
	
	public void GameLoop() {
		if (originT == null) return;

		if (isRelativeToLocalAxis) originT.rotation *= Quaternion.AngleAxis(rotateSpeed, rotateAxis); 	//Local axis
		else originT.rotation = Quaternion.AngleAxis(rotateSpeed, rotateAxis) * originT.rotation; 		//Global axis
	}

	[ContextMenu("SetThisGameObjectAsOrigin")]
	public void SetThisGameObjectAsOrigin() {
		origin = this.gameObject;
	}
	
	void Update () { 		if (!inLateUpdate && !inFixedUpdate) GameLoop (); }
	void LateUpdate () { 	if (inLateUpdate && !inFixedUpdate) GameLoop (); }
	void FixedUpdate () {	if (inFixedUpdate && !inLateUpdate) GameLoop (); }
}
