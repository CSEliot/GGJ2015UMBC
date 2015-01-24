using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	Ray rayOrigin;
	RaycastHit hitInfo;
	Vector3 rayOriginStart;
	bool ableToInteract;

	public Button crossHair;
	public float reach;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}

	void Update () {
	}

	// Update is called once per frame
	void FixedUpdate () {

		//make a pointer to trigger events for the ui without needing to move the mouse around
		PointerEventData pointer = new PointerEventData(EventSystem.current);


		rayOriginStart = transform.FindChild ("Main Camera").transform.position / transform.FindChild ("Main Camera").transform.position.magnitude;
		
		rayOrigin = new Ray(transform.FindChild("Main Camera").transform.position + transform.FindChild("Main Camera").transform.forward * 0.05f, transform.FindChild("Main Camera").transform.forward);

		//if you are able to reach something, anything important or not
		if (Physics.Raycast (rayOrigin, out hitInfo, reach)) {

			//every if statement will now check for whether we hit an interactable object or not
			if (hitInfo.transform.tag == "table") {
				ableToInteract = true;
			}
		}

		//highlight crosshair to signal possible interaction
		if (ableToInteract) {
			ExecuteEvents.Execute(crossHair.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
		}
		if (!ableToInteract) {
			ExecuteEvents.Execute(crossHair.gameObject, pointer, ExecuteEvents.pointerExitHandler);		
		}

		//end update with disabling interaction
		ableToInteract = false;
	}
}
