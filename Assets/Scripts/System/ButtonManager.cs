using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//
public class ButtonManager : MonoBehaviour
{
    public List<Button> baseButtonList = new List<Button>();
    public List<GameObject> childButtonList = new List<GameObject>();

    private int lastButtonNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (childButtonList != null)
        {
            foreach (GameObject item in childButtonList)
                item.gameObject.SetActive(false);
        }
        if (baseButtonList != null)
        {
            for (int i = 0; i < baseButtonList.Count; i++)
            {
                int j = i;
                baseButtonList[i].onClick.AddListener(() => OnButtonClick(j));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnButtonClick(int i)
    {
        childButtonList[i].gameObject.SetActive(!childButtonList[i].gameObject.activeSelf);
        lastButtonNumber = i;
    }
}
