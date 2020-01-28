using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float speed;
    public GameObject bulletPref;

    public virtual void Move()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * speed;
        transform.rotation = new Quaternion(0f, 0f, rotationZ, 1);
    }

    public virtual void Shoot()
    {
        Instantiate(bulletPref, transform.position, Quaternion.identity, transform);
    }
}