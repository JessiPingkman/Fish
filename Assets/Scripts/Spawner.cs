using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPref;
    public GameObject bulletPref;
    public Transform spawnTransformEnemy;
    public Transform spawnTransformBullet;
    public Player player;

    private const int MAX_SPAWN_ENEMY = 10;
    private enum Site
    {
        left,
        rigth,
        up,
        down
    }

    private void Awake()
    {
        for (int i = 0; i < MAX_SPAWN_ENEMY; i++)
            SpawnEnemy();
    }

    private void OnEnable()
    {
        EventManager.StartListening("SpawnEnemy", SpawnEnemy);
        EventManager.StartListening("SpawnBullet", SpawnBullet);
    }

    private void OnDisable()
    {
        EventManager.StopListening("SpawnEnemy", SpawnEnemy);
        EventManager.StopListening("SpawnBullet", SpawnBullet);
    }


    public void SpawnEnemy()
    {
        System.Random randomSite = new System.Random();
        Site spawnSite = (Site)randomSite.Next(Enum.GetNames(typeof(Site)).Length);
        Vector2 randomPoint = Vector2.zero;
        switch (spawnSite)
        {
            case Site.left:
                randomPoint = new Vector2(Screen.width, UnityEngine.Random.Range(-Screen.height, Screen.height));
                break;
            case Site.down:
                randomPoint = new Vector2(UnityEngine.Random.Range(-Screen.width, Screen.width), -Screen.height);
                break;
            case Site.rigth:
                randomPoint = new Vector2(-Screen.width, UnityEngine.Random.Range(-Screen.width, Screen.width));
                break;
            case Site.up:
                randomPoint = new Vector2(UnityEngine.Random.Range(-Screen.width, Screen.width), Screen.height);
                break;
        }

        Vector2 saveSpawnPoint = Camera.main.ScreenToWorldPoint(randomPoint);
        GameObject enemy = Instantiate(enemyPref, saveSpawnPoint, Quaternion.identity, spawnTransformEnemy);
        Vector2 vectorToPlater = player.transform.position - enemy.transform.position;
        enemy.transform.rotation = Quaternion.FromToRotation(Vector2.down, vectorToPlater);
    }

    public void SpawnBullet()
    {
        Instantiate(bulletPref, transform.position, Quaternion.identity, spawnTransformBullet);
    }
}
