using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	Ray rayOrigin;
	RaycastHit hitInfo;
	Vector3 rayOriginStart;
	bool ableToInteract;

	public float reach;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		rayOriginStart = transform.FindChild ("Main Camera").transform.position / transform.FindChild ("Main Camera").transform.position.magnitude;
		
		rayOrigin = new Ray(transform.FindChild("Main Camera").transform.position + transform.FindChild("Main Camera").transform.forward * 0.05f, transform.FindChild("Main Camera").transform.forward);

		if (Physics.Raycast (rayOrigin, out hitInfo, reach)) {
			if (hitInfo.transform.tag == "table") {
				ableToInteract = true;
				Debug.Log("hit table");
			}
		}
	}
}
