using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private bool IsFree;
    private TaskList tl;
    private PlaceObject po;
    private VillagerMove vm;
    private TaskList.BlockInfo getPlaceBlock;
    // Start is called before the first frame update
    void Start()
    {
        IsFree = true;
        tl = GameObject.Find("System").GetComponent<TaskList>();
        po = this.GetComponent<PlaceObject>();
        vm = this.GetComponent<VillagerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetFree())
        {
            GetPlaceBlock();
            if (getPlaceBlock != null)
            {
                po.SetPlaceBlock(getPlaceBlock);
                po.SetPlaced(false);
                vm.SetTargetDestination(getPlaceBlock.position);
                SetFree(false);
                Debug.Log("5 : ");
            }
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

    public void GetPlaceBlock()
    {
        getPlaceBlock = tl.DeQueueBlockSet();
    }
}
