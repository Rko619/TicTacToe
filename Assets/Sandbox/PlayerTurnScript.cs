using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerTurnScript : MonoBehaviour {

	[SerializeField]
	private Image player1Info,player2Info;


	public void GiveTurn(TURN CURRENTPLAYERTURN)
	{
		Image currentInfoImage=null;

		if(currentInfoImage)
		{
			currentInfoImage.color=new Color(currentInfoImage.color.r,currentInfoImage.color.g,currentInfoImage.color.b,50f);
		}

		switch(CURRENTPLAYERTURN)
		{
			case TURN.PLAYER1:
			currentInfoImage=player1Info;
			break;

			case TURN.PLAYER2:
			currentInfoImage=player2Info;
			break;

			case TURN.NONE:
			currentInfoImage=null;
			player1Info.color=new Color(player1Info.color.r,player1Info.color.g,player1Info.color.b,50f);
			player2Info.color=new Color(player2Info.color.r,player2Info.color.g,player2Info.color.b,50f);
			break;

			default:
			break;
		}

		if(currentInfoImage)
		{
			currentInfoImage.color=new Color(currentInfoImage.color.r,currentInfoImage.color.g,currentInfoImage.color.b,50f);	player1Info.color=new Color(player1Info.color.r,player1Info.color.g,player1Info.color.b,255f);

		}
	}
}
