using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public virtual void BulletFlight()
    {
        rb.AddRelativeForce(Camera.main.ScreenToWorldPoint(Input.mousePosition) * speed, ForceMode2D.Impulse);
    }
}
