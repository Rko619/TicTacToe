using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class XOType
{
    public enum playerId
    {
        X,O,None
    }
	public Sprite currentSprite;
	public playerId currentPlayerID;
	public bool isOccupied;

    public int rowId,coulmnId;
    public Image buttonImage;
    public Button associatedButton;
    public GameObject relatedGameobject;
    public  XOType(Sprite _currentSprite,playerId _currentPlayerID,bool _isOccupied,int _rowId,int _columnId,Button _buttonAssociated,Image _buttonImage,GameObject _relatedGameobject)
    {
        currentSprite=_currentSprite;
        currentPlayerID=_currentPlayerID;
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
                int _i=i,_j=j;
                n.AddComponent<Button>().onClick.AddListener(delegate{UpdateButtonSprite(n,_i,_j);});
                n.GetComponent<Button>().transition=Button.Transition.None;
                matrixGrid[i,j]=new XOType(null,XOType.playerId.None,false,i,j,n.GetComponent<Button>(),n.GetComponent<Image>(),n);
            }
        }
    }

    void UpdateButtonSprite(GameObject buttonGameObject,int row,int column)
    {
            matrixGrid[row,column].buttonImage.sprite=x;
            matrixGrid[row,column].isOccupied=true;
            matrixGrid[row,column].associatedButton.interactable=false;
            matrixGrid[row,column].currentPlayerID=XOType.playerId.O;
    }

    bool CheckIdentityValues()
    {
        //checking for normal identity values in the matrixGrid 2d array
        XOType.playerId tempId=matrixGrid[0,0].currentPlayerID;
        for(int i=0;i<gridSize;i++)
        {
            if((tempId!=matrixGrid[i,i].currentPlayerID)&&(matrixGrid[i,i].isOccupied))
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
         XOType.playerId tempId=matrixGrid[0,gridSize-1].currentPlayerID;
        int n=0,row=0,column=gridSize-1;
        while(n<gridSize-1)
        {
            row=row+1;
            column=column-1;
            if((tempId!=matrixGrid[row,column].currentPlayerID)&&(matrixGrid[row,column].isOccupied))
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
            XOType.playerId tempId=matrixGrid[i,0].currentPlayerID;

            for(int j=0;j<gridSize;j++)
            {
                if((tempId!=matrixGrid[i,j].currentPlayerID)&&(matrixGrid[i,j].isOccupied))
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
                XOType.playerId tempId=matrixGrid[j,i].currentPlayerID;

                if((tempId!=matrixGrid[j,i].currentPlayerID)&&(matrixGrid[j,i].isOccupied))
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
    void InitializeVisualGridSize()
    {
        blocksSpawnGridRoot.GetComponent<GridLayoutGroup>().constraintCount=gridSize;
    }
}

