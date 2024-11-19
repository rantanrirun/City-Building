using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public bool IsFree;
    private TaskList tl;
    // Start is called before the first frame update
    void Start()
    {
        IsFree = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFree)
        {

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

    public void A()
    {
        TaskList.BlockInfo a = tl.DeQueueBlockSet();
    }
}
