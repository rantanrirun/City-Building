using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private bool IsFree;
    private TaskList publicTl;
    private TaskList myTl;
    private PlaceObject po;
    private VillagerMove vm;
    private TaskList.BlockInfo getPlaceBlock;
    public string myName;
    // Start is called before the first frame update
    void Start()
    {
        IsFree = true;
        publicTl = GameObject.Find("System").GetComponent<TaskList>();
        myTl = this.GetComponent<TaskList>();
        po = this.GetComponent<PlaceObject>();
        vm = this.GetComponent<VillagerMove>();
        myName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetFree())
        {
            SetPlaceBlock();
        }
    }
    ///<summary>
    ///ヒマか否かを返す。ヒマならtrue.
    ///</summary>
    public bool GetFree()
    {
        return IsFree;
    }

    ///<summary>
    ///IsFreeを引数の値にする。
    ///</summary>
    public void SetFree(bool value)
    {
        IsFree = value;
    }
    ///<summary>
    ///タスクの取得
    ///</summary>
    public void GetPlaceBlock()
    {
        getPlaceBlock = myTl.DeQueueBlockSet();
        if (getPlaceBlock == null)
        {
            getPlaceBlock = publicTl.DeQueueBlockSet();
        }
    }
    ///<summary>
    ///タスクを消化する
    ///</summary>
    public void SetPlaceBlock()
    {
        GetPlaceBlock();
        if (getPlaceBlock != null)
        {
            po.SetPlaceBlock(getPlaceBlock);
            po.SetPlaced(false);
            vm.SetTargetDestination(getPlaceBlock.position);
            SetFree(false);
        }
    }
    public TaskList GetMyTl()
    {
        return myTl;
    }
}
