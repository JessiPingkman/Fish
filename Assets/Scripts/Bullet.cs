using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed = 1;

    private Vector2 endPoint;
    private bool isMove = true;
    private const string EVENT_UPDATE_COUNT_ENEMY_LABEL = "UpdateCountEnemyLable";


    private void Awake()
    {
        endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isMove = true;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPoint, _bulletSpeed);
        if((Vector2)transform.position == endPoint && isMove)
        {
            isMove = !isMove;
            Kill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var entity = collision.GetComponent<Enemy>();
        if (entity != null)
        {
            entity.Kill();
            Kill();
            EventManager.TriggerEvent(EVENT_UPDATE_COUNT_ENEMY_LABEL);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
