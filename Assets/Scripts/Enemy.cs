using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string SHOW_GAMEOVER_LABEL = "ShowGameOverLabel";
    private const string KILL_PLAYER = "KillPlayer";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            EventManager.TriggerEvent(KILL_PLAYER);
            EventManager.TriggerEvent(SHOW_GAMEOVER_LABEL);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
