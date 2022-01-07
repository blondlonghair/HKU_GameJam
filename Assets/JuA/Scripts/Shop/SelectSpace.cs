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
    private TextMeshProUGUI price;
    private TooltipContent content;
    private Button button;
    private ShopItem item;

    private void Awake()
    {
        isCheck = false;
        image = gameObject.transform.Find("Content Image").GetComponent<Image>();
        Name = gameObject.transform.Find("Content Name").GetComponent<TextMeshProUGUI>();
        price = gameObject.transform.Find("Price").GetComponent<TextMeshProUGUI>();
        content = GetComponentInChildren<TooltipContent>();
        button = GetComponentInChildren<Button>();
        button.onClick.AddListener(() => Check());

        RandomSet();
    }

    public void Buy()
    {
        if (JongChan.GameManager.Instance.Gold < item.price) return;
        JongChan.GameManager.Instance.Gold -= item.price;
        item.UseAbility();
        button.GetComponent<Animator>().Play("Out");
        isCheck = false;
        RandomSet();
    }

    public int GetPrice()
    {
        return item.price;
    }

    public void RandomSet()
    {
        Set(ShopItemFactory.GetRandomItem());
    }

    private void Set(ShopItem shop)
    {
        item = shop;
        Name.text = item.NameText;
        price.text = item.price.ToString() + "$";
        content.description = item.contentText;
        image.sprite = item.sprite;
    }


    private void Check()
    {
        if (isCheck) isCheck = false;
        else isCheck = true;
    }
}
