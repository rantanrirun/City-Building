using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public GameObject block;//置くblockのこと
    private bool placed;//trueかfalseを返す　trueが置いた、falseが置いてない
    private WorldGrid wg;
    private VillagerMove vm;
    private Villager villager;
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
                    DeleteBlock(position);
                }
                else
                {
                    villager.SetFree(true);
                }
            }
        }
    }

    ///<summary>
    ///選択したオブジェクトを消す。引数 position は消す場所。
    ///</summary>
    public void DeleteBlock(Vector3 position)
    {
        if (!wg.CheckGridAvailable(position))
        {
            Debug.Log("消す物発見");
            Destroy(wg.GetGridItem(position));
            placed = true;
        }
        else
        {
            Debug.Log("消す物ないよ");
            return;
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
    public void SetDeleteBlock(TaskList.BlockInfo info)
    {
        position = info.position;
        block = info.block;
    }
}
