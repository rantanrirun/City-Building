using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class VillagerUI : MonoBehaviour
{
    public Button crossButton;
    public RectTransform villagerPanel;
    public ClickPoint clickPoint;
    public TextMeshProUGUI nameText;
    // Start is called before the first frame update
    void Start()
    {
        if (crossButton != null)
        {
            crossButton.onClick.AddListener(() => OnButtonClick());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ViewPanel(Villager villager)
    {
        nameText.text = villager.myName;
        villagerPanel.DOAnchorPos(new Vector2(0f, 0), 0.6f)
    .SetEase(Ease.OutBack);
    }
    public void OnButtonClick()
    {
        villagerPanel.DOAnchorPos(new Vector2(260f, 0), 0.6f)
    .SetEase(Ease.OutBack);
        clickPoint.ClearVillager();
    }
}
