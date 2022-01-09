using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private float coolTime;
    private float curtime;

    void Update()
    {
        if (curtime <= 0)
        {
            Spawn();
            curtime = coolTime;
        }
        curtime -= Time.deltaTime;
    }

    void Spawn()
    {
        Vector3 position = new Vector3();
        Quaternion rotation = new Quaternion();
        switch (Random.Range(1,5))
        {
            case 1:
                position = new Vector3(Random.Range(-590, 590), 30, 340);
                rotation = Quaternion.Euler(90, 0, Random.Range(-150, -30));
                break;
            case 2:
                position = new Vector3(Random.Range(-590, 590), 30, -340);
                rotation = Quaternion.Euler(90, 0, Random.Range(30, 150));
                break;
            case 3:
                position = new Vector3(-590, 30, Random.Range(-340, 340));
                rotation = Quaternion.Euler(90, 0, Random.Range(-60, 60));
                break;
            case 4:
                position = new Vector3(590, 30, Random.Range(-340, 340));
                rotation = Quaternion.Euler(90, 0, Random.Range(-240, -120));
                break;
        }

        var n = Instantiate(spawnObject, position, rotation);
    }
}
