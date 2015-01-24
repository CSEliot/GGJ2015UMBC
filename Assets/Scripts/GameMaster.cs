using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Reflection;

public class GameMaster : MonoBehaviour {

	[Serializable]
	public struct GAME_VALUES{

		//###################################
		//PLAYER VARIABLES
		//###################################
		public float movementSpeed; 
		public float runningSpeed;
		public float mouseSensetivity;// = 10.0f;
		public float upDownRange;// = 70.0f;
		public float jumpHeight;// = 10.0f;
		public float jumpCount;
		public float maxHealth;
		public bool invertControls;
		public bool invertMouseY;
		public bool noStrafe;
		public bool canZoom;
		

		//###################################
		//ENVIRONMENT VARIABLES
		//###################################
		public float gravity;
		public bool jumpingAllowed;
		public bool runningAllowed;
		public bool miniMapEnabled;
		public bool drunkMode;

		//###################################
		//MOD CONTENT ENABLED
		//###################################
		//GUNS/WEAPONS-----------------------
		//basic gun mods
		public float fireInterval_Basic;
		public float bulletSpeed_Basic;
		public float gunWeight_Basic;
		public float bulletLife_Basic;

		//Characters------------------------	
		public bool robots;

		//Maps-------------------------------
		public bool ColumnArena;
		public bool GridArena;
	}

	private bool disabledChars;
	private string magicWinButton = "\\";
	public GAME_VALUES _M;
	private int sizeX = 150;
	private int sizeY = 150;
	private bool gameOver = false;

	

	void Start(){
		

		disabledChars = false;
		if(Application.isEditor)Save_Values();
		Screen.lockCursor = true;
		Load_Values();
		gameObject.camera.pixelRect = new Rect(Screen.width/2 - sizeX/2, Screen.height/2 - sizeY/2, sizeX, sizeY);
		if(_M.miniMapEnabled){
			gameObject.camera.enabled = true;
		}
	}

	void Update(){
        if (!disabledChars)
        {
            GameObject[] tempList = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in tempList)
            {
                //if robots are enabled
                if (_M.robots)
                {
                    //if it is indeed a robot
                    if (player.transform.GetChild(0).name == "UpperTorse+Camera")
                    {
                        player.SetActive(true);
                    }
                    else
                    {
                        player.SetActive(false);
                    }
                }
                else
                {
                    //if it is indeed a robot
                    if (player.transform.GetChild(0).name == "UpperTorse+Camera")
                    {
                        player.SetActive(false);
                    }
                    else
                    {
                        player.SetActive(true);
                    }
                }
            }
            disabledChars = true;
        }
		if(Input.GetKeyDown("q") || Input.GetKeyDown("escape"))
		{
			Save_Values();
			
			Application.Quit();

		}
		if(Input.GetKeyDown(magicWinButton)){

			GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player");
			for(int i = 0; i < allPlayers.Length-1; i++){
				allPlayers[i].SetActive(false); //disables all but one player, making a winner.
			}
		}
		if(GameObject.FindGameObjectsWithTag("Player").Length == 1){
		        gameOver = true;
				Screen.lockCursor = false;
		}   
	}


	public void Save_Values(){
		GameMaster masterScript;
		masterScript = GameObject.Find("Game Master").GetComponent<GameMaster>();

		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream("GM.bin", FileMode.Create, FileAccess.Write, FileShare.None);
		formatter.Serialize(stream, masterScript._M);
		stream.Close();

	}

	private void Load_Values(){
		IFormatter formatter = new BinaryFormatter();
		Stream stream = new FileStream("GM.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
		_M = (GAME_VALUES) formatter.Deserialize(stream);
		stream.Close();

	}
	
	public bool isGameOver(){
		return gameOver;
	}
}
