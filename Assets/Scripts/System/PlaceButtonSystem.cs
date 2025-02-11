using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceButtonSystem : MonoBehaviour
{
    private ClickPoint cp;
    public GameObject block;
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
        cp.item = block;
    }
}
