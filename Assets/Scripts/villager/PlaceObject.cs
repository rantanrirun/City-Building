using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public GameObject put;
    public bool placed;//trueかfalseを返す　trueが置いた、falseが置いてない
    private WorldGrid wg;
    private Vector3 placePosition;
    // Start is called before the first frame update
    void Start()
    {
        placed = false;
        wg = GameObject.Find("World Grid").GetComponent<WorldGrid>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    ///<summary>
    ///オブジェクトを置く。引数 position は置く場所。
    ///</summary>
    public void Installation(Vector3 position)
    {
        if (put == null)
        {
            Debug.Log("置く物ないよ");
            return;
        }
        if (!wg.CheckGridAvailable(position))
        {
            Debug.Log("配置済み");
            placed = true;
        }
        else
        {
            //placePosition = position + new Vector3(0.5f, 0f, 0.5f);
            //putを目的地の場所に初期状態でコピーする。
            Instantiate(put, position, Quaternion.identity);
            placed = true;
            wg.SetValueToWorldGrid(position, put);
        }
    }
    ///<summary>
    ///置き終わったか否かを返す。置き終わったらtrue.
    ///</summary>
    public bool IsPlaced()
    {
        return placed;
    }

    ///<summary>
    ///placedを引数の値にする。
    ///</summary>
    public void SetPlaced(bool value)
    {
        placed = value;
    }
}
