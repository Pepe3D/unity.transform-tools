using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : TransformToolBase 
{
	public float radious = 0.5f;
	public float lerpSpeed = 1f;
	public float timeBetweenPositions = 1f;
	public float fps = 60f;
	public bool waveSlerp = true;

	private float waveFrames = 0f;
	private Vector3 newDestination; 

	protected override void GameLoop() 
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
}
