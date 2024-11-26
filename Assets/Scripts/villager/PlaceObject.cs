using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public GameObject block;//置くblockのこと
    private bool placed;//trueかfalseを返す　trueが置いた、falseが置いてない
    private WorldGrid wg;
    private VillagerMove vm;
    private Villager villager;
    private Vector3 placePosition;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        placed = false;
        wg = GameObject.Find("World Grid").GetComponent<WorldGrid>();
        vm = this.GetComponent<VillagerMove>();
        villager = this.GetComponent<Villager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPlaced())//agentの目的地が有効であり、かつ物をまだ置いてない場合
        {
            if (vm.IsArriveDestination())
            {
                Debug.Log("arrive");
                if (vm.DistanceToPlacePoint())
                {
                    Installation(position);
                }
            }
        }

    }

    ///<summary>
    ///オブジェクトを置く。引数 position は置く場所。
    ///</summary>
    public void Installation(Vector3 position)
    {
        if (block == null)//blockが何もない場合(バグ対策)
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
            //blockを目的地の場所に初期状態でコピーする。
            Instantiate(block, position, Quaternion.identity);
            placed = true;
            wg.SetValueToWorldGrid(position, block);
        }
        villager.SetFree(true);
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

    ///<summary>
    ///それぞれを変数に代入する。
    ///</summary>
    public void SetPlaceBlock(TaskList.BlockInfo info)
    {
        position = info.position;
        block = info.block;
    }
}
