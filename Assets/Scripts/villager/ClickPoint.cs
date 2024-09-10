using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPoint : MonoBehaviour
{
    private Vector3 targetPosition;
    public VillagerMove villagerMove;
    public PlaceObject po;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    //
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                targetPosition = new Vector3(Mathf.RoundToInt(targetPosition.x), Mathf.RoundToInt(targetPosition.y), Mathf.RoundToInt(targetPosition.z));
                //Debug.Log("座標" + targetPosition);
                villagerMove.SetTargetDestination(targetPosition);
                po.SetPlaced(false);
            }
        }
    }
}
