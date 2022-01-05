using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Michsky.UI.ModernUIPack;

public class SelectSpace : MonoBehaviour
{
    private bool isCheck;
    public bool IsCheck { get { return isCheck; } }
    private Image image;
    private TextMeshProUGUI Name;
    private TooltipContent content;
    private Button button;
    private ShopItem item;

    private void Awake()
    {
        isCheck = false;
        image = gameObject.transform.Find("Content Image").GetComponent<Image>();
        Name = GetComponentInChildren<TextMeshProUGUI>();
        content = GetComponentInChildren<TooltipContent>();
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(() => Check());

        Set(ShopItemFactory.GetItem(1, 4));
    }

    void Set(ShopItem shop)
    {
        item = shop;
        Name.text = item.NameText;
        content.description = item.contentText;
        image.sprite = item.sprite;
    }

    private void Check()
    {
        if (isCheck) isCheck = false;
        else isCheck = true;
    }
}
