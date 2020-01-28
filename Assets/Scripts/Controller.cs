using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Player player;
    public GameObject enemyPref;
    public Canvas gameCanvas;
    public Canvas gameOverCanvas;
    public TextMeshProUGUI countDeathEnemy;
    public TextMeshProUGUI countPoints;

    public static Controller self;
    public static int count;

    private void Awake()
    {
        self = this;
        gameOverCanvas.gameObject.SetActive(false);
        count = 0;
        countDeathEnemy.text = "0";
        StartCoroutine(ISpawnEnemy());
    }

    private IEnumerator ISpawnEnemy()
    {
        while (player != null)
        {
            Instantiate(enemyPref, GetRandomPoint(), Quaternion.identity, gameCanvas.transform);
            yield return new WaitForSeconds(1f);
        }
        countPoints.text = count.ToString();
        gameOverCanvas.gameObject.SetActive(true);
    }

    public static Vector2 GetRandomPoint()
    {
        return new Vector2(Random.Range(-self.gameCanvas.pixelRect.height, -self.gameCanvas.pixelRect.height + 5), Random.Range(-self.gameCanvas.pixelRect.height, self.gameCanvas.pixelRect.height + 5));
    }

    //script moveble
    //script rotatible

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
