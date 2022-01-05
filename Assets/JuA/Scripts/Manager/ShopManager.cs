using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class ShopManager : Singleton<ShopManager>
{
    private GameObject Shop;
    private CanvasGroup ShopGroup;
    private List<SelectSpace> ShopList;

    private void Awake()
    {
        Shop = Instantiate(Resources.Load<GameObject>("Prefabs/Shop"), GameObject.Find("Canvas").transform);
        ShopGroup = Shop.GetComponent<CanvasGroup>();
        ShopList = Shop.GetComponentsInChildren<SelectSpace>().ToList();

        Shop.SetActive(false);
        ShopGroup.alpha = 0;

        Button button = Shop.transform.Find("Buy").GetComponent<Button>();
        button.onClick.AddListener(() => BuyAll());
    }

    private void Start()
    {
        LoadShop();
    }

    public void LoadShop()
    {
        Shop.SetActive(true);
        DOTween.To(() => ShopGroup.alpha, x => ShopGroup.alpha = x, 0.8f, 0.5f);
    }

    public void ExitShop()
    {
        Shop.SetActive(true);
        DOTween.To(() => ShopGroup.alpha, x => ShopGroup.alpha = x, 0, 0.5f);
    }

    public void RandomSetSelection()
    {
        foreach (SelectSpace i in ShopList)
            i.RandomSet();
    }

    public void BuyAll()
    {
        int sum = 0;
        foreach(SelectSpace i in ShopList)
            if (i.IsCheck) sum += i.GetPrice();

        if (sum > GameManager.Instance.GetShipStats().Gold)
        {
            UIManager.Instance.ShowNotification("Error!!!", "Not enough gold!", 4f);
            return;
        }
        else
        {
            foreach (SelectSpace i in ShopList)
                if (i.IsCheck) i.Buy();
            UIManager.Instance.ShowNotification("Payment completed", "Your payment has been processed successfully.", 4f);
        }
    }
}
