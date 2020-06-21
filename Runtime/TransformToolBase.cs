using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToolBase : MonoBehaviour
{
    public GameObject origin;
	public GameObject target;

    [Header("Options")]
    public bool inLateUpdate = false;
    public bool setMainCameraAsOrigin = false;
    public bool setMainCameraAsTarget = false;

    protected Transform originT;
	protected Transform targetT;

    protected virtual void GameLoop() {}

    protected virtual void OnEnable() 
	{
        if (setMainCameraAsOrigin) origin = Camera.main?.gameObject;
        if (setMainCameraAsTarget) target = Camera.main?.gameObject;
        if (origin == null) origin = gameObject;

		if (origin != null) originT = origin.GetComponent<Transform>();
		if (target != null) targetT = target.GetComponent<Transform>();
	}

    void Update() 
    { 		
        if (!inLateUpdate) GameLoop(); 
    }
	
    void LateUpdate() 
    { 	
        if (inLateUpdate) GameLoop(); 
    }

    [ContextMenu("CreateTargetObject")]
	public void CreateTargetObject() 
    {
		target = new GameObject("TargetOf_" + gameObject.name);
		target.transform.position = gameObject.transform.position + gameObject.transform.forward;
	}

    public void SetOriginAndTarget(GameObject originGO = null, GameObject targetGO = null) 
    {
        if (originGO != null) origin = originGO;
        if (targetGO != null) target = targetGO;
    }
}
