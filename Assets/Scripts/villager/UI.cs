using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Button blockButton;
    private bool IsFree;
    // Start is called before the first frame update
    void Start()
    {
        if (blockButton != null)
        {
            blockButton.onClick.AddListener(() => OnButtonClick());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetBlockInfo()
    {
        //return IsFree;
    }
    public void OnButtonClick()
    {
        Debug.Log("ボタンon");
    }
}
