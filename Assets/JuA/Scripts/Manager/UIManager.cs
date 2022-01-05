using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;
using DG.Tweening;

public class UIManager : Singleton<UIManager>
{
    private GameObject NotificationPrefab;
    private GameObject Canvas;

    private void Awake()
    {
        NotificationPrefab = Resources.Load<GameObject>("Prefabs/Notification");
        Canvas = GameObject.Find("Canvas");
    }

    public void ShowNotification(string title, string content, float time, float wait = 0.5f)
    {
        var ob = Instantiate(NotificationPrefab, Canvas.transform);
        NotificationManager n = ob.GetComponent<NotificationManager>();
        n.title = title;
        n.description = content;
        n.timer = time;
        StartCoroutine(ShowNoti(n, wait));
    }

    List<RectTransform> Notification = new List<RectTransform>();
    IEnumerator ShowNoti(NotificationManager n, float wait)
    {
        yield return new WaitForSeconds(wait);
        for(int i = 0; i < Notification.Count; i++)
        {
            Notification[i].DOAnchorPos(new Vector2(-300, 150 + 250 * (Notification.Count - i)), 0.5f);
        }
        Notification.Add(n.GetComponent<RectTransform>());

        n.OpenNotification();
        yield return new WaitForSeconds(n.timer);
        Notification.Remove(n.GetComponent<RectTransform>());
        yield return new WaitForSeconds(2f);
        Destroy(n.gameObject);
    }
}
