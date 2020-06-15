using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public GameObject origin;
	public float radious = 0.5f;
	public float lerpSpeed = 1f;
	public float timeBetweenPositions = 1f;
	public float fps = 60f;
	public bool waveSlerp = true;

	[Header("Update")]
	public bool inLateUpdate = false;
	public bool inFixedUpdate = false;

	private float waveFrames = 0f;
	private Vector3 newDestination; 
	private Transform originT;

	void OnEnable() 
	{
		if (origin != null) originT = origin.GetComponent<Transform>();
	}

	public void GameLoop() 
	{
		if (originT == null) return;

		waveFrames--;
		if (waveFrames <= 0f) {
			newDestination = Random.onUnitSphere * radious;
			waveFrames = timeBetweenPositions * fps;
		}
		
		if (waveSlerp) originT.localPosition = Vector3.Slerp(originT.localPosition, newDestination, Time.fixedDeltaTime * lerpSpeed);
		else originT.localPosition = Vector3.Lerp(originT.localPosition, newDestination, Time.fixedDeltaTime * lerpSpeed);
	}

	[ContextMenu("SetThisGameObjectAsOrigin")]
	public void SetThisGameObjectAsOrigin() {
		origin = this.gameObject;
	}

	void Update () { 		if (!inLateUpdate && !inFixedUpdate) GameLoop (); }
	void LateUpdate () { 	if (inLateUpdate && !inFixedUpdate) GameLoop (); }
	void FixedUpdate () {	if (inFixedUpdate && !inLateUpdate) GameLoop (); }
}
