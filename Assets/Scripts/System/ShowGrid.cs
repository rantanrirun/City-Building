using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGrid : MonoBehaviour
{
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log(hit.point);
            targetPosition = hit.point;
            targetPosition = new Vector3(Mathf.RoundToInt(targetPosition.x), Mathf.RoundToInt(targetPosition.y), Mathf.RoundToInt(targetPosition.z));
            //targetPosition += new Vector3(0.5f, 0.01f, 0.5f);
            targetPosition.y += 0.01f;
            transform.position = targetPosition;
        }
    }
}