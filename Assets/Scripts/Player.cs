using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //if (hit.transform.GetComponent<Enemy>() != null)
            //{
            //}
        }
    }
}