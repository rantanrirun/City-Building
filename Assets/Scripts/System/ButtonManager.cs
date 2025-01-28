using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Reflection;
//
public class ButtonManager : MonoBehaviour
{
    public List<Button> baseButtonList = new List<Button>();
    public List<GameObject> childButtonList = new List<GameObject>();
    private int lastButtonNumber;
    public EventTrigger eventTrigger;

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

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((x) =>
        {
            Trigger(x);
        });
        eventTrigger.triggers.Add(entry);
    }
    // Update is called once per frame
    void Update()
    {

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
        }
        childButtonList[i].gameObject.SetActive(!childButtonList[i].gameObject.activeSelf);//押されたボタンが開いてたら閉じ、閉じてたら開く
    }
    void Trigger(BaseEventData baseEventData)
    {
        if (baseEventData.pointerId == -1)
        {
            childButtonList[lastButtonNumber].gameObject.SetActive(false);
        }
        Debug.Log("Trigger" + lastButtonNumber);
    }
}
