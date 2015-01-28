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
		if(Input.GetButtonUp("p1_Fire") && this.GetComponent<FirstPersonController>().getIsCarrying() == true){
			//Debug.Log("SUBMIT BUTTON GOING UP");
			this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = true;
			this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
			this.gameObject.transform.GetChild(0).GetChild(0).parent = null;
			//deactivate collider
			this.GetComponent<FirstPersonController>().setCarrying(false);
		}
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
			if (hitInfo.transform.tag == "Item" && this.GetComponent<FirstPersonController>().getIsCarrying() == false) {
				ableToInteract = true;
				if(Input.GetButtonDown("p1_Fire")){
					hitInfo.transform.parent = this.gameObject.transform.GetChild(0).transform;
					//deactivate collider
					this.GetComponent<FirstPersonController>().setCarrying(true);
					this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider>().enabled = false;
					this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
				}
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
