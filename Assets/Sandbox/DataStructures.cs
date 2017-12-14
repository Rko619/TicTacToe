using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public enum TURN{ PLAYER1,PLAYER2,AI,NONE }
public enum ID{ X,O,NONE }


public struct PlayersData
{
    public ID PlayerID;
    public Sprite assignedSprite;

    public PlayersData(ID _PlayerID,Sprite _assignedSprite)
    {
        PlayerID=_PlayerID;
        assignedSprite=_assignedSprite;
    }
}

public struct InputData
{
    public GameObject buttonGameObject;
    public int buttonRow;
    public int buttonColumn;
    public InputData(GameObject _buttonGameObject,int _buttonRow,int _buttonColumn)
    {
        buttonGameObject=_buttonGameObject;
        buttonRow=_buttonRow;
        buttonColumn=_buttonColumn;
    }
  
}
