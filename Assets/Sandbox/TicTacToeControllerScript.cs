using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class XOType: MonoBehaviour
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
	private XOType[,] matrix=new XOType[gridSize,gridSize];



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
        for(int i=0;i<3;i++)
        {
            for(int j=0;j<3;j++)
            {
                GameObject n=new GameObject();
                n.transform.SetParent(blocksSpawnGridRoot.transform);
                n.name=i.ToString()+","+j.ToString();
                n.AddComponent<Image>().sprite=normalSprite;
                n.AddComponent<Button>().onClick.AddListener(delegate{UpdateButtonSprite(n,i,j);});
                matrix[i,j]=new XOType(null,XOType.playerId.None,false,i,j,n.GetComponent<Button>(),n.GetComponent<Image>(),n);
            }
        }
    }

    public void UpdateButtonSprite(GameObject buttonGameObject,int row,int column)
    {
            buttonGameObject.GetComponent<Image>().sprite=x;
            
            Debug.Log(buttonGameObject.name);
    }
}

