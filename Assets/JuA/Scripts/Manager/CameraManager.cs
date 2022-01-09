using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField] private GameObject camPosOne;
    [SerializeField] private GameObject camPosTwo;
    [SerializeField] private GameObject subCamera;

    private ViewType viewType;
    public ViewType ViewType { get => viewType; set => viewType = value; }

    private void Awake()
    {
        if (camPosOne == null) camPosOne = GameObject.Find("CM vcam1");
        if (camPosTwo == null) camPosTwo = GameObject.Find("CM vcam2");
        if (subCamera == null) subCamera = GameObject.Find("Sub Camera");

        camPosOne.SetActive(true);
        camPosTwo.SetActive(false);
        subCamera.SetActive(false);

        ViewType = ViewType.Charater;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) CamViewSwitch(viewType == ViewType.Ship ? ViewType.Charater : ViewType.Ship);
        if (Input.GetKeyDown(KeyCode.V)) ViewSubCamera(!subCamera.activeSelf);
    }

    public void CamViewSwitch(ViewType view)
    {
        viewType = view;

        if (view == ViewType.Ship)
        {
            camPosOne.SetActive(false);
            camPosTwo.SetActive(true);

            JongChan.GameManager.Instance.PlayerCanAction = false;
        }
        else if (view == ViewType.Charater)
        {
            camPosOne.SetActive(true);
            camPosTwo.SetActive(false);

            JongChan.GameManager.Instance.PlayerCanAction = true;
        }
    }
    
    public void ViewSubCamera(bool on)
    {
        subCamera.SetActive(on);
    }
}

public enum ViewType
{
    Ship,
    Charater
}