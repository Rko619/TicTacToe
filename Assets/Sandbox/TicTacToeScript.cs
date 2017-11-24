using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeScript : MonoBehaviour
{
    public static TicTacToeScript instance;
    public Sprite x, o;
    public bool isPlayer1=true;
    public bool[,] customMatrix=new bool[3][3];


    void OnEnable()
    {
        instance = this;
    }


    public void OnClick()
    {
        if (isPlayer1)
        {
            isPlayer1 = false;

        }
        else
        {
            isPlayer1 = true;
        }
    }
}

