using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameModeScript : MonoBehaviour {

	[SerializeField]
	private GameObject gameInfoPanel;
	public enum TURN
	{
		PLAYER1,PLAYER2,AI,NONE
	}

	private TURN  PLAYERTURN;

	public void GiveChance(TURN whichPlayersTurn)
	{
		gameInfoPanel.GetComponent<PlayerTurnScript>().GiveTurn(whichPlayersTurn);
	}
}
