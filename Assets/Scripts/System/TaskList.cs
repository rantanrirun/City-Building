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
    ///置きたい場所とブロックという情報をQueueに追加。
    ///</summary>
    public void EnQueueBlockSet(Vector3 position, GameObject block)
    {
        targetPos = position;
        BlockInfo temp = new BlockInfo();//tempという場所を用意、中身はまだない。
        temp.position = targetPos;//tempのpositionという場所にtargetPosという情報を入れた。
        temp.block = block;//tempのblockという場所にblockという情報を入れた。
        blockSetTasks.Enqueue(temp);//tempをblockSetTasksに追加。
    }

    public BlockInfo DeQueueBlockSet()
    {
        BlockInfo bo = blockSetTasks.Dequeue();
        return bo;
    }
}
