using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    public GameGrid[,] ground = new GameGrid[1000, 1000];
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Initialize()
    {
        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < 1000; j++)
            {
                ground[i, j] = new GameGrid();
                ground[i, j].objectType = 0;
                ground[i, j].item = null;
            }
        }
    }

    ///<summary>
    ///既に物が配置済みか確認するメソッド。何もない[0]の場合に true を返す。
    ///</summary>
    public bool CheckGridAvailable(Vector3 pos)
    {
        Debug.Log("Grid(" + pos.x + ", " + pos.z + ") : " + ground[(int)pos.x + 500, (int)pos.z + 500].objectType);

        if (ground[(int)pos.x + 500, (int)pos.z + 500].objectType == 0)//グリッドをずらすのではなく、クリックポイントを+500ずらしている。
        {
            Debug.Log("CheckGridAvailable true");
            return true;
        }
        else
        {
            Debug.Log("CheckGridAvailable false");
            return false;
        }
    }

    ///<summary>
    ///配列に保存するメソッド。
    ///</summary>
    public void SetValueToWorldGrid(Vector3 pos, GameObject obj)
    {
        ground[(int)pos.x + 500, (int)pos.z + 500].objectType = obj.GetComponent<ObjectInfo>().objectType;
        ground[(int)pos.x + 500, (int)pos.z + 500].item = obj;
        Debug.Log("ワールドグリッドに登録しました。");
    }

    [Serializable]
    public class GameGrid
    {
        public int objectType;//置いてあるものの種類
        /*
        0:何もない
        1:ブロック
        2:
        */
        public GameObject item;//置いてあるものそのもの
    }
}
