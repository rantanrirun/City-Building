using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceButtonSystem : MonoBehaviour
{
    private ClickPoint cp;
    public GameObject block;
    public bool isDelete;
    // Start is called before the first frame update
    void Start()
    {
        cp = GameObject.Find("Player").GetComponent<ClickPoint>();
        GetComponent<Button>().onClick.AddListener(() => OnButtonClick());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnButtonClick()
    {
        if (isDelete && block == null)
        {
            cp.item = null;
        }
        else if (block != null)
        {
            cp.item = block;
        }
    }
}
