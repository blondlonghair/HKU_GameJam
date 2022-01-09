using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float cool;
    private float curtime;
    private Transform target;

    private void Start()
    {
        target = GameObject.Find("MyShip").transform;
        curtime = cool;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion n = Quaternion.LookRotation(dir.normalized);
        n = Quaternion.Euler(n.eulerAngles.x, n.eulerAngles.y - 90, n.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, n, Time.deltaTime * 0.5f);
        if (!moveStop) transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    bool moveStop = false;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("MyShip"))
        {
            moveStop = true;
            JongChan.GameManager.Instance.ShipCurHp -= damage;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("MyShip"))
        {
            curtime -= Time.deltaTime;
            if (curtime <= 0)
            {
                if (Random.Range(0,2) == 0) JongChan.GameManager.Instance.SpawnEnemy();
                curtime = cool;
            }
        }
    }
}
