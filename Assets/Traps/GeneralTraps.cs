using UnityEngine;
using System.Collections;

public class GeneralTraps : MonoBehaviour {

	/*
	 * Traps
	 * J.T Klopcic 
	 * Make sure that trap has a trigger attached to the model with desired range. 
	 * Also make sure that it is apropriatly tagged with the type of trap it is. 
	 * 
	 * 
	*/


	public bool activatedTrap;
	public GameObject BearTrap;



	void OnTriggerEnter(Collider other)
	{
		//Switch trap to actived status 
		activatedTrap = true; 

		//as long as trap was activated by the player. 
		if (activatedTrap && other.gameObject.CompareTag("Player") )
		{
			//Determine which of trap was activated and perform that action for it. 
			Debug.Log("Player has activated an trap");


			if(this.tag == "Pit" )
			{
				Debug.Log("Player has fallen into a pit");
				//kill the player
				other.gameObject.transform.GetComponent<FirstPersonController>.killPlayer(); 

		

				//reset the trap
				activatedTrap = false; 

			}
			else if(this.tag == "Steam")
			{
				//activate the steam	
				 
				Debug.Log("Player has entered steam");
				// Steam();

			}


			else if(this.tag == "Mine")
			{
				Debug.Log("Player went by a mine");
				//kill the player
				other.gameObject.transform.GetComponent<FirstPersonController>.killPlayer(); 
					
				//reset the trap
				activatedTrap = false; 

				 
			}

			else if(this.tag == "BearTrap")
			{
				Debug.Log("Player has gotten caught in a bear trap"); 


				BearTrap.animation.Play();

				//kill the player 
				other.gameObject.transform.GetComponent<FirstPersonController>.killPlayer(); 
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

			Debug.Log("Player has exited trap"); 
		}
	}


	void Steam()
	{

				
				//subtract from time at quicker rate

		

	}



}
