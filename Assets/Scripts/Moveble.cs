using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveble : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0f, 0f), _moveSpeed * Time.deltaTime);
    }
}
