using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShip : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private float coolTime;
    private float curtime;

    float z = 0;
    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) z -= Time.deltaTime * 60;
        if (Input.GetKey(KeyCode.A)) z += Time.deltaTime * 60;
        Arrow.transform.rotation = Quaternion.Euler(90, 0, z);

        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Z) || Input.GetKeyDown(KeyCode.Z))
            {
                Instantiate(bullet, transform.position, Quaternion.Euler(90, 0, z));
                SoundManager.Instance.PlaySFXSound("ShipShoot");
                curtime = coolTime;
            }
        }
        curtime -= Time.deltaTime;
    }
}
