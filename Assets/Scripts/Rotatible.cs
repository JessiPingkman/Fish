using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatible : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 1;

    private void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = (Vector2.Angle(Vector2.down, mousePosition - (Vector2)transform.position) * _rotateSpeed);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.x < mousePosition.x ? angle : -angle);
    }
}
