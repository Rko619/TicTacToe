using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ClickScript : MonoBehaviour {

    public bool isX;

    public void OnClick()
    {
        Image m = GetComponent<Image>();
        if (TicTacToeScript.instance.isPlayer1)
        {
            m.sprite = TicTacToeScript.instance.x;
            TicTacToeScript.instance.OnClick();
            isX = true;
        }
        else
        {
            m.sprite = TicTacToeScript.instance.o;
            TicTacToeScript.instance.OnClick();
            isX = false;
        }

    }
}
