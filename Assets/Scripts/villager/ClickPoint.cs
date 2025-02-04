using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickPoint : MonoBehaviour
{
    private Vector3 targetPosition;
    public TaskList tl;
    public PlaceObject po;
    public WorldGrid wg;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        tl = GameObject.Find("System").GetComponent<TaskList>();
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
                targetPosition = hit.point;
                targetPosition = new Vector3(Mathf.RoundToInt(targetPosition.x), Mathf.RoundToInt(targetPosition.y), Mathf.RoundToInt(targetPosition.z));
                //Debug.Log("座標" + targetPosition);
                SetTask();
            }
        }
    }
    public void SetTask()
    {
        if (wg.CheckGridAvailable(targetPosition))
        {
            tl.EnQueueBlockSet(targetPosition, item);
        }
    }

}
