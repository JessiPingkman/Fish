using UnityEngine;

public class Player : MonoBehaviour
{
    private const string SPAWN_BULLET = "SpawnBullet";
    private const string SPAWN_ENEMY = "SpawnEnemy";

    private void OnEnable()
    {
        EventManager.StartListening("KillPlayer", Kill);
    }
    private void OnDisable()
    {
        EventManager.StopListening("KillPlayer", Kill);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != null)
            {
                var entity = hit.transform.gameObject.GetComponent<Enemy>();
                if (entity != null)
                {
                    EventManager.TriggerEvent(SPAWN_BULLET);
                    EventManager.TriggerEvent(SPAWN_ENEMY);
                }
            }
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}