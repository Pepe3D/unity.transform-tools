using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {

	public GameObject origin;
	public float rotateSpeed = 2f;
	public Vector3 rotateAxis;
	public bool isRelativeToLocalAxis;
	public bool inLateUpdate = false;

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
	
	void Update() { 		if (!inLateUpdate) GameLoop(); }
	void LateUpdate() { 	if (inLateUpdate) GameLoop(); }
}
