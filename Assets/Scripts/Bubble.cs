using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Bullet
{
    private void Awake()
    {
        BulletFlight();
    }

    private void Update()
    {
        if (transform.localPosition.x > Screen.width || transform.position.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Controller.count++;
            Controller.self.countDeathEnemy.text = Controller.count.ToString();
            Destroy(collision.GetComponent<Enemy>().gameObject);
            Destroy(gameObject);
        }
    }
}
