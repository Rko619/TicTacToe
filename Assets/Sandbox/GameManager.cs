using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

    public GameModeScript gameMode;


    void Awake()
    {
        instance=this;
    }
	
}
