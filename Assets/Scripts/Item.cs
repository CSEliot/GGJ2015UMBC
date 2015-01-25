using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public int Wieght =  5; 

	// Use this for initialization
	void Start () 
	{
		//make sure that this object is tagged with as an item
		this.tag = "Item"; 

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
