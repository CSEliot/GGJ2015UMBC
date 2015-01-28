using UnityEngine;
using System.Collections;

public class BuildShipCheck : MonoBehaviour {

	public AudioClip buildingShip;

	//set up a list to find the 5 ship pieces
	public GameObject part1;
	public GameObject part2;
	public GameObject part3;
	public GameObject part4;
	public GameObject part5;

	public GameObject ship;
	private bool shipSpawned = false;

	//the average distance between all other parts relative to part 1
	private float avgDistance;
	
	private float distance1to2;
	private float distance1to3;
	private float distance1to4;
	private float distance1to5;
	
	private float distanceSum;
	
	//position of this object
	private Vector3 posPart1;
	private Vector3 posPart2;
	private Vector3 posPart3;
	private Vector3 posPart4;
	private Vector3 posPart5;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//get the five locations of the three parts
		posPart1 = part1.transform.position;
		posPart2 = part2.transform.position;
		posPart3 = part3.transform.position;
		posPart4 = part4.transform.position;
		posPart5 = part5.transform.position;
		
		//distance between 1 and 2
		float directionMagnitude = (posPart1 - posPart2).magnitude;
		distance1to2 = directionMagnitude;
		
		//distance between 1 and 3
		float directionMagnitude1 = (posPart1 - posPart3).magnitude;
		distance1to3 = directionMagnitude1;
		
		//distance between 1 and 4
		float directionMagnitude2 = (posPart1 - posPart4).magnitude;
		distance1to4 = directionMagnitude2;
		
		//distance between 1 and 5
		float directionMagnitude3 = (posPart1 - posPart5).magnitude;
		distance1to5 = directionMagnitude3;
		
		distanceSum = distance1to2 + distance1to3 + distance1to4 + distance1to5;
		avgDistance = distanceSum / 4f;

        //if(Time.time%2f>1.5f)Debug.Log("Avg Distance is: " + avgDistance);

		if (avgDistance < 4f && !GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().getIsCarrying() && !shipSpawned) {
			//assemble ship player wins
			Debug.Log("player wins and builds ship");

			part1.SetActive(false);
			part2.SetActive(false);
			part3.SetActive(false);
			part4.SetActive(false);
			part5.SetActive(false);

			Vector3 whereToSpawn;

			whereToSpawn = new Vector3(part1.transform.position.x, part1.transform.position.y + 10f, part1.transform.position.z);
			GameObject newShip;
			newShip = Instantiate(ship, whereToSpawn, Quaternion.Euler(-90f, -180f, -180f)) as GameObject;
			shipSpawned = true;

			audio.PlayOneShot(buildingShip);
		}
	}
}

