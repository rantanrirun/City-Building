using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickPoint : MonoBehaviour
{
    private Vector3 targetPosition;
    public TaskList publicTl;
    public PlaceObject po;
    public WorldGrid wg;
    public GameObject item;
    [SerializeField] private Villager villager;
    // Start is called before the first frame update
    void Start()
    {
        publicTl = GameObject.Find("System").GetComponent<TaskList>();
        villager = null;
    }

    // Update is called once per frame

    //
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Villager>())
                {
                    villager = hit.collider.gameObject.GetComponent<Villager>();
                    Debug.Log(hit.collider.gameObject.name);
                }
                else if (villager)
                {
                    targetPosition = hit.point;
                    targetPosition = new Vector3(Mathf.RoundToInt(targetPosition.x), Mathf.RoundToInt(targetPosition.y), Mathf.RoundToInt(targetPosition.z));
                    Debug.Log("SetmyTl");
                    SetTask(villager.GetMyTl());
                }
                else
                {
                    targetPosition = hit.point;
                    targetPosition = new Vector3(Mathf.RoundToInt(targetPosition.x), Mathf.RoundToInt(targetPosition.y), Mathf.RoundToInt(targetPosition.z));
                    //Debug.Log("座標" + targetPosition);
                    SetTask(publicTl);
                }
            }
        }
    }
    /// <summary>
    /// Queueに登録する情報(置く位置と置くブロック)
    /// </summary>
    public void SetTask(TaskList tl)
    {
        if (wg.CheckGridAvailable(targetPosition))
        {
            tl.EnQueueBlockSet(targetPosition, item);
        }
    }
}
