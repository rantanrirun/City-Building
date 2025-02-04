using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Reflection;
//
public class ButtonManager : MonoBehaviour
{
    public List<Button> baseButtons = new List<Button>();
    public List<GameObject> childButtonList = new List<GameObject>();
    public List<Button> childButtons = new List<Button>();
    public List<GameObject> grandChildButtonList = new List<GameObject>();
    private int lastButtonNumber;
    private int lastChildButtonNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (childButtonList != null)
        {
            foreach (GameObject item in childButtonList)
                item.gameObject.SetActive(false);
        }
        if (grandChildButtonList != null)
        {
            foreach (GameObject item in grandChildButtonList)
                item.gameObject.SetActive(false);
        }
        if (baseButtons != null)
        {
            for (int i = 0; i < baseButtons.Count; i++)
            {
                int j = i;
                baseButtons[i].onClick.AddListener(() => OnButtonClick(j));
            }
        }
        if (childButtons != null)
        {
            for (int i = 0; i < childButtons.Count; i++)
            {
                int k = i;
                childButtons[i].onClick.AddListener(() => OnChildButtonClick(k));
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current != null && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                childButtonList[lastButtonNumber].gameObject.SetActive(false);
                grandChildButtonList[lastChildButtonNumber].gameObject.SetActive(false);
                Debug.Log("Trigger" + lastButtonNumber);
            }
        }
    }
    ///<summary>
    ///ボタンのON/OFFをまとめて管理する
    ///</summary>
    void OnButtonClick(int i)
    {
        if (i != lastButtonNumber)//別のボタンを押したら前のボタンを閉じる
        {
            childButtonList[lastButtonNumber].gameObject.SetActive(false);
            lastButtonNumber = i;
            grandChildButtonList[lastChildButtonNumber].gameObject.SetActive(false);
            lastChildButtonNumber = i;
        }
        childButtonList[i].gameObject.SetActive(!childButtonList[i].gameObject.activeSelf);//押されたボタンが開いてたら閉じ、閉じてたら開く
    }
    void OnChildButtonClick(int i)
    {
        if (i != lastChildButtonNumber)//別のボタンを押したら前のボタンを閉じる
        {
            grandChildButtonList[lastChildButtonNumber].gameObject.SetActive(false);
            lastChildButtonNumber = i;
        }
        grandChildButtonList[i].gameObject.SetActive(!grandChildButtonList[i].gameObject.activeSelf);//押されたボタンが開いてたら閉じ、閉じてたら開く
    }
}
