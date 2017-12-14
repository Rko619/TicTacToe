using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameModeScript : MonoBehaviour
{

	[SerializeField]
	private TicTacToeControllerScript tictactoeScript;
	private PlayersData player1Data,player2Data,currentPlayerData;



	void Start()
	{
		GameManager.instance.gameMode=this;
	}
	public void OnUserClicked(InputData i)
	{
		tictactoeScript.UpdateMatrixData(i,currentPlayerData);
	}




}
