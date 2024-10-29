using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    private Vector3 targetPos;
    public class BlockInfo
    {
        public Vector3 position;
        public GameObject item;
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
    public void AddQueueBlockSet(Vector3 position, GameObject item)
    {
        targetPos = position;
        BlockInfo temp = new BlockInfo();//tempという場所を用意、中身はまだない。
        temp.position = targetPos;//tempのpositionという場所にtargetPosという情報を入れた。
        temp.item = item;//tempのitemという場所にitemという情報を入れた。
        blockSetTasks.Enqueue(temp);//tempをblockSetTasksに追加。
    }
}
