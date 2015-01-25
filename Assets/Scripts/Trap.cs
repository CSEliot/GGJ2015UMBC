using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	/*
	 * Trap
	 * J.T Klopcic 
	 * Make sure that trap has a trigger attached to the model with desired range. 
	 * Also make sure that it is apropriatly tagged with the type of trap it is. 
	 * 
	 * 
	*/


	public bool activatedTrap = false, rockWarning; 
	bool activeSteam = false; 
	GameObject SpikeArm; 
	public GameObject smallRock, bigRock,Spawner; 

	void Update()
	{
		if (activeSteam) 
		{
			isSprung(); 
		}


	}

	void OnTriggerEnter(Collider other)
	{
		//Switch trap to actived status 
		activatedTrap = true; 

		//as long as trap was activated by the player. 
		if (activatedTrap && other.gameObject.CompareTag("Player") )
		{
			//Determine which of trap was activated and perform that action for it. 
			Debug.Log("Hit");


			if(this.tag == "Spikes" )
			{
				Debug.Log("spikes");
				//kill the player
				other.gameObject.transform.GetComponent<FirstPersonController>().killPlayer();

		

				//reset the trap
				activatedTrap = false; 

			}
			else if(this.tag == "Steam")
			{
				//activate the steam	
				activeSteam = true; 
				Debug.Log("enter");
				isSprung(); 

			}
			else if(this.tag == "Mine")
			{
				Debug.Log("Mine");
				//kill the player
				//FirstPersonController.killPlayer(); 

			


				
				//reset the trap
				activatedTrap = false; 

				 
			}

			else if(this.tag == "Rocks")
			{

				StartCoroutine(DropSmallRocks()); 


				if(!rockWarning)
				{
					Debug.Log("Waiting");
					StartCoroutine(DropSmallRocks());

				}


				if(rockWarning)
				{
					Debug.Log("Moving to big rocks"); 
					// drop big rocks
					StartCoroutine(DropBigRocks());
					Debug.Log("Rock");

				}

				

				
				//reset the trap
				activatedTrap = false; 


				 
			}
			else if(this.tag == "Pit")
			{
				Debug.Log("Pit"); 
				//kill the player 
				//FirstPersonController.killPlayer(); 
			}

			else 
			{
				Debug.Log("There is no trap type defined. Please define trap type with tag in the inspector window");

			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			//when the player leaves steam deactivate steam proccess 
			activeSteam = false; 
			rockWarning = false; 
			Debug.Log("exit"); 
		}
	}


	void isSprung()
	{

				Debug.Log("Steam");
				//subtract from health

		

	}

	IEnumerator DropSmallRocks()
	{




		if (!rockWarning) 
		{


			//Drop big 4 rocks
			for(int i = 0; i <= 3; i++)
			{
			Instantiate(smallRock,Spawner.transform.position, Spawner.transform.rotation);
			yield return new WaitForSeconds(.75f); 
			}


			rockWarning = false;
			yield return new WaitForSeconds (4); 
			Debug.Log("Dropped small"); 


		}



	}

	IEnumerator DropBigRocks()
	{

		if(rockWarning) 
		{

			
			//drop 3 big rocks
			for(int i = 0; i <= 3; i++)
			{
				Instantiate(bigRock,Spawner.transform.position, Spawner.transform.rotation);
				yield return new WaitForSeconds(1); 
			}
			rockWarning = false; 
			Debug.Log("Dropped big rocks");
		}
	}

}
