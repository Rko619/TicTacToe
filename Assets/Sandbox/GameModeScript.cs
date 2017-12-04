using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public struct PlayerTurnData
	{
		public TURN  CURRENTPLAYERTURN;
		public Sprite spriteChoosed;
		public SPRITEID XORO;
	}



public class GameModeScript : MonoBehaviour {


	public static GameModeScript gameModeScriptInstance;
	
	[SerializeField]
	private GameObject gameInfoPanel;

	void Start()
	{
		gameModeScriptInstance=this;
	}
	public void GiveChance(TURN whichPlayersTurn)
	{
		gameInfoPanel.GetComponent<PlayerTurnScript>().GiveTurn(whichPlayersTurn);
	}
	void SetPlayerPresets()
	{

	}
	public void OnUserInput(GameObject respectiveButtonGameObject,int buttonRowIndex,int buttonColumnIndex)
	{

	}

}
