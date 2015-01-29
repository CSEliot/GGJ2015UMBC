using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class make_help : MonoBehaviour {


    public GameObject plane;
    public GameObject player;
    public Canvas canvas;
    private bool thingEnabled;
    
	// Use this for initialization
	void Start () {
        thingEnabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("POOP");

        float distance = Vector3.Distance(player.transform.position, plane.transform.position);
        //;Debug.Log(distance);
        if (distance > 15f && thingEnabled)
        {
            thingEnabled = false;
			
			canvas.transform.GetChild(3).gameObject.SetActive(false);
            Debug.Log("ENABLING");
        }
        else if (thingEnabled == false && distance < 15f)
        {
			canvas.transform.GetChild(3).gameObject.SetActive(true);
            thingEnabled = true;
			Debug.Log("Disabled");
        }
       }

	}

