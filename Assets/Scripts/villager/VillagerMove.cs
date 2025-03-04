using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerMove : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    private PlaceObject po;
    private Vector3 targetPos;
    private float placeDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        po = this.GetComponent<PlaceObject>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    ///<summary>
    ///引数の座標を目的地とする。
    ///</summary>
    public void SetTargetDestination(Vector3 position)
    {
        agent.SetDestination(position);//positionはクリックした場所を保存
        targetPos = position;
    }

    ///<summary>
    ///AIの目的地と村人"VillagerMoveメソッドがセットされてるオブジェクト"の距離が一定以下ならtrue
    ///</summary>
    public bool IsArriveDestination()
    {
        if (Vector3.Distance(agent.destination, this.transform.position) <= 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    ///<summary>
    ///クリックした場所と村人"VillagerMoveメソッドがセットされてるオブジェクト"の距離が一定以下ならtrue
    ///</summary>
    public bool DistanceToPlacePoint()
    {
        if (Vector3.Distance(targetPos, this.transform.position) <= placeDistance)
        {
            return true;
        }
        else
        {
            Debug.Log("届かないよ");
            po.SetPlaced(true);
            return false;
        }
    }
}
