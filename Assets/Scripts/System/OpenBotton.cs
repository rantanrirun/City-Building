using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class OpenBotton : MonoBehaviour
{
    private GameObject allButtons;
    private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button = this.GetComponent<Button>();
        allButtons = transform.Find("AllButtons").gameObject;

        if (allButtons != null)
        {
            allButtons.gameObject.SetActive(false);
        }
        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("blockButtonがないよ");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnButtonClick()
    {
        allButtons.gameObject.SetActive(!allButtons.gameObject.activeSelf);
    }
}
