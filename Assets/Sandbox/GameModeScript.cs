using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameModeScript : MonoBehaviour {

	public enum TURN
	{
		PLAYER1,PLAYER2,AI,NONE
	}
	[SerializeField]
	private Image player1Info,player2Info;
	private TURN  PLAYERTURN;

	void GiveChance()
	{
		
	}
}
