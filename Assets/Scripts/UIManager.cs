using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public TextMeshProUGUI countDeathEnemy;
    public TextMeshProUGUI countFinishPoints;

    private int countPoint;

    private void OnEnable()
    {
        EventManager.StartListening("ShowGameOverLabel", ShowGameOverLabel);
        EventManager.StartListening("UpdateCountEnemyLable", UpdateCountEnemyLable);
    }
    private void OnDisable()
    {
        EventManager.StopListening("ShowGameOverLabel", ShowGameOverLabel);
        EventManager.StopListening("UpdateCountEnemyLable", UpdateCountEnemyLable);
    }

    private void Awake()
    {
        countPoint = 0;
        countDeathEnemy.text = "0";
        HideGameOverLable();
    }

    public void UpdateCountEnemyLable()
    {
        countPoint++;
        countDeathEnemy.text = countPoint.ToString();
    }

    public void ShowGameOverLabel()
    {
        gameOverCanvas.gameObject.SetActive(true);
        countFinishPoints.text = countPoint.ToString();
    }

    public void HideGameOverLable()
    {
        gameOverCanvas.gameObject.SetActive(false);
    }
}