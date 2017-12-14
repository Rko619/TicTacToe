using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class XOType
{
	public Sprite currentSprite;
	public ID CurrentPlayerID;
	public bool isOccupied;

    public int rowId,coulmnId;
    public Image buttonImage;
    public Button associatedButton;
    public GameObject relatedGameobject;

    //Class for matrix 
    public  XOType(Sprite _currentSprite,ID _currentPlayerID,bool _isOccupied,int _rowId,int _columnId,Button _buttonAssociated,Image _buttonImage,GameObject _relatedGameobject)
    {
        currentSprite=_currentSprite;
        CurrentPlayerID=_currentPlayerID;
        isOccupied=_isOccupied;
        rowId=_rowId;
        coulmnId=_columnId;
        buttonImage=_buttonImage;
        associatedButton=_buttonAssociated;
        relatedGameobject=_relatedGameobject;
    }
}




public class TicTacToeControllerScript : MonoBehaviour
{
    public static TicTacToeControllerScript instance;

    [SerializeField]
    private Sprite x, o,normalSprite;

    [SerializeField]
    private GameObject blocksSpawnGridRoot;

    private static int gridSize=3;
	private XOType[,] matrixGrid=new XOType[gridSize,gridSize];




    void SetGridSize()
    {
        blocksSpawnGridRoot.GetComponent<GridLayoutGroup>().constraintCount=gridSize;
    }
    void InitializeBlocks()
    {
        for(int i=0;i<gridSize;i++)
        {
            for(int j=0;j<gridSize;j++)
            {
                GameObject g=new GameObject();
                g.transform.SetParent(blocksSpawnGridRoot.transform);
                g.name=i.ToString()+","+j.ToString();
                g.AddComponent<Image>().sprite=normalSprite;
                int _buttonRowIndex=i,_buttonColumnIndex=j;

                //Assigning every  button with same function
                //create a input data struct and pass all values through it
                InputData _inputData=new InputData(g,_buttonRowIndex,_buttonColumnIndex);
                g.AddComponent<Button>().onClick.AddListener(delegate{OnButtonClicked(_inputData);});


                g.GetComponent<Button>().transition=Button.Transition.None;
                matrixGrid[i,j]=new XOType(null,ID.NONE,false,i,j,g.GetComponent<Button>(),g.GetComponent<Image>(),g);
            }
        }
    }


    void OnButtonClicked(InputData i)
    {
        GameManager.instance.gameMode.OnUserClicked(i);
    }

    //called after every time user pressed
    public void UpdateMatrixData(InputData _inputData,PlayersData _playerData)
    {
            matrixGrid[_inputData.buttonRow,_inputData.buttonColumn].isOccupied=true;
            matrixGrid[_inputData.buttonRow,_inputData.buttonColumn].CurrentPlayerID=_playerData.PlayerID;
            matrixGrid[_inputData.buttonRow,_inputData.buttonColumn].buttonImage.sprite=_playerData.assignedSprite;
            matrixGrid[_inputData.buttonRow,_inputData.buttonColumn].associatedButton.interactable=false;
            Debug.Log("you win ="+CheckForWinning());
    }

    bool CheckForWinning()
    {
        if(CheckIdentityValues()||CheckReverseIdentityValues()||CheckNormalIndices())
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    bool CheckIdentityValues()
    {
        //checking for normal identity values in the matrixGrid 2d array
        ID tempId=matrixGrid[0,0].CurrentPlayerID;
        for(int i=0;i<gridSize;i++)
        {
            if((tempId!=matrixGrid[i,i].CurrentPlayerID)&&(matrixGrid[i,i].isOccupied))
            {
                return false;
            }
            else if(!matrixGrid[i,i].isOccupied)
            {
                return false;
            }
        }
        return true;
    }

    bool CheckReverseIdentityValues()
    {
        //checking for identity values but invers of it
         ID tempId=matrixGrid[0,gridSize-1].CurrentPlayerID;
        int n=0,row=0,column=gridSize-1;
        while(n<gridSize-1)
        {
            row=row+1;
            column=column-1;
            if((tempId!=matrixGrid[row,column].CurrentPlayerID)&&(matrixGrid[row,column].isOccupied))
            {
                return false;
            }
            else if(!matrixGrid[row,column].isOccupied)
            {
                return false;
            }
            n++;
        }
        return true;
    }

    bool  CheckNormalIndices()
    {
        //check for normla parallel rows and columns
        bool isTallied=false;
        for(int i=0;i<gridSize;i++)
        {
            if(isTallied)
            {
                return true;
            }
            ID tempId=matrixGrid[i,0].CurrentPlayerID;

            for(int j=0;j<gridSize;j++)
            {
                if((tempId!=matrixGrid[i,j].CurrentPlayerID)&&(matrixGrid[i,j].isOccupied))
                {
                    isTallied=false;
                    break;
                }
                else if(!matrixGrid[i,j].isOccupied)
                {
                    isTallied=false;
                    break;
                }
                else if(matrixGrid[i,j].isOccupied)
                {
                    isTallied=true;
                }
            }
        }

         for(int i=0;i<gridSize;i++)
        {
            if(isTallied)
            {
                return true;
            }
            for(int j=0;j<gridSize;j++)
            {
                ID tempId=matrixGrid[j,i].CurrentPlayerID;

                if((tempId!=matrixGrid[j,i].CurrentPlayerID)&&(matrixGrid[j,i].isOccupied))
                {
                    isTallied=false;
                    break;
                }
                else if(!matrixGrid[j,i].isOccupied)
                {
                    isTallied=false;
                    break;
                }
                else if(matrixGrid[j,i].isOccupied)
                {
                    isTallied=true;
                }
            }
        }
        return isTallied;

    }


}

