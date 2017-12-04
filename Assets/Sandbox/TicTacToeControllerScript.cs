using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class XOType
{
	public Sprite currentSprite;
	public SPRITEID CURRENTPLAYERSPRITEID;
	public bool isOccupied;

    public int rowId,coulmnId;
    public Image buttonImage;
    public Button associatedButton;
    public GameObject relatedGameobject;
    public  XOType(Sprite _currentSprite,SPRITEID _currentPlayerID,bool _isOccupied,int _rowId,int _columnId,Button _buttonAssociated,Image _buttonImage,GameObject _relatedGameobject)
    {
        currentSprite=_currentSprite;
        CURRENTPLAYERSPRITEID=_currentPlayerID;
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
    public bool isPlayer1=true;
    private static int gridSize=3;
	private XOType[,] matrixGrid=new XOType[gridSize,gridSize];




    void OnEnable()
    {
        instance = this;
        InitializeBlocks();
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

    void InitializeBlocks()
    {
        for(int i=0;i<gridSize;i++)
        {
            for(int j=0;j<gridSize;j++)
            {
                GameObject n=new GameObject();
                n.transform.SetParent(blocksSpawnGridRoot.transform);
                n.name=i.ToString()+","+j.ToString();
                n.AddComponent<Image>().sprite=normalSprite;
                int _rowIndex=i,_columnIndex=j;
                //Assigning every  button which a function
                n.AddComponent<Button>().onClick.AddListener(delegate{OnButtonClicked(n,_rowIndex,_columnIndex);});
                n.GetComponent<Button>().transition=Button.Transition.None;
                matrixGrid[i,j]=new XOType(null,SPRITEID.NONE,false,i,j,n.GetComponent<Button>(),n.GetComponent<Image>(),n);
            }
        }
    }


    void OnButtonClicked(GameObject buttonGameObject,int buttonRowIndex,int buttonColumnIndex)
    {
        GameModeScript.gameModeScriptInstance.OnUserInput(buttonGameObject,buttonRowIndex,buttonColumnIndex);
    }

    //called after every time user pressed
    void UpdateMatrixData(GameObject buttonGameObject,int row,int column,SPRITEID _spriteID)
    {
            matrixGrid[row,column].isOccupied=true;
            matrixGrid[row,column].CURRENTPLAYERSPRITEID=_spriteID;
            Debug.Log("you win ="+CheckForWinning());
    }

    public void UpdateButtonSprite(GameObject buttonGameObject,int row,int column,Sprite spriteToChange)
    {
        matrixGrid[row,column].buttonImage.sprite=spriteToChange;
         matrixGrid[row,column].associatedButton.interactable=false;

    }
    bool CheckIdentityValues()
    {
        //checking for normal identity values in the matrixGrid 2d array
        SPRITEID tempId=matrixGrid[0,0].CURRENTPLAYERSPRITEID;
        for(int i=0;i<gridSize;i++)
        {
            if((tempId!=matrixGrid[i,i].CURRENTPLAYERSPRITEID)&&(matrixGrid[i,i].isOccupied))
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
         SPRITEID tempId=matrixGrid[0,gridSize-1].CURRENTPLAYERSPRITEID;
        int n=0,row=0,column=gridSize-1;
        while(n<gridSize-1)
        {
            row=row+1;
            column=column-1;
            if((tempId!=matrixGrid[row,column].CURRENTPLAYERSPRITEID)&&(matrixGrid[row,column].isOccupied))
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
            SPRITEID tempId=matrixGrid[i,0].CURRENTPLAYERSPRITEID;

            for(int j=0;j<gridSize;j++)
            {
                if((tempId!=matrixGrid[i,j].CURRENTPLAYERSPRITEID)&&(matrixGrid[i,j].isOccupied))
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
                SPRITEID tempId=matrixGrid[j,i].CURRENTPLAYERSPRITEID;

                if((tempId!=matrixGrid[j,i].CURRENTPLAYERSPRITEID)&&(matrixGrid[j,i].isOccupied))
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
    void InitializeVisualGridSize()
    {
        blocksSpawnGridRoot.GetComponent<GridLayoutGroup>().constraintCount=gridSize;
    }
}

