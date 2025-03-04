using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    private Vector3 targetPos;
    public class BlockInfo
    {
        public Vector3 position;
        public GameObject block;
        public bool isPlace;
    }
    Queue<BlockInfo> blockSetTasks;
    // Start is called before the first frame update
    void Start()
    {
        blockSetTasks = new Queue<BlockInfo>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    ///<summary>
    ///置きたい位置とブロックという情報をQueueに追加。
    ///</summary>
    public void EnQueueBlockSet(Vector3 position, GameObject block, bool isPlaces)
    {
        targetPos = position;
        BlockInfo temp = new BlockInfo();//tempという場所を用意、中身はまだない。
        temp.position = targetPos;//tempのpositionという場所にtargetPosという情報を入れた。
        temp.block = block;//tempのblockという場所にblockという情報を入れた。
        temp.isPlace = isPlaces;
        blockSetTasks.Enqueue(temp);//tempをblockSetTasksに追加。
    }
    /// <summary>
    /// 置きたい位置とブロックという情報をQueueから取り出す。
    /// </summary>
    /// <returns>位置・ブロック</returns>
    public BlockInfo DeQueueBlockSet()
    {
        if (blockSetTasks.Count == 0)
        {
            return null;
        }
        BlockInfo bo = blockSetTasks.Dequeue();
        return bo;
    }
}
