using UnityEngine;
using System.Collections;

public class DeathTracker : MonoBehaviour {


	private int totalDeaths;

	// Use this for initialization
	void Start () {
		totalDeaths = 0;
	}
	
	// Update is called once per frame
	void Update () {	
		
	}

	public void increaseDeathCount(){
		totalDeaths += 1;
	}

	public int getDeathCount(){
		return totalDeaths;
	}
}
