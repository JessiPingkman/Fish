using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private void Update()
    {
        Move();
    }

    private void Awake()
    {
        if(transform.localPosition.x > Controller.GetRandomPoint().x || transform.localPosition.x < Controller.GetRandomPoint().x)
        {
            transform.localPosition = Controller.GetRandomPoint();
        }
    }

    public override void Move()
    {
        if (Controller.self.player == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, Controller.self.player.transform.position, speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            Destroy(Controller.self.player);
        }
    }
}
