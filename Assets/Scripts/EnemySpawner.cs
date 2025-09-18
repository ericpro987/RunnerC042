using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*[SerializeField]
    List<Enemy> Enemy;*/
    [SerializeField]
    Enemy enemy;
    [SerializeField]
    JumpingEnemy jumpingEnemy;
    [SerializeField]
    int spawnTime;
    [SerializeField]
    GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager.changeRound += NextRound;
        spawnTime = 3;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (gameManager.round < 2)
            {
                Enemy e = Instantiate(enemy);
                e.transform.position = new Vector3(12.18f, -3, 0);
            }else if(gameManager.round < 3)
            {
                int chooseEnemy = Random.Range(0, 2);
                if (chooseEnemy == 0)
                {
                    Enemy e = Instantiate(enemy);
                    e.transform.position = new Vector3(12.18f, -3, 0);
                }
                else
                {
                    JumpingEnemy e = Instantiate(jumpingEnemy);
                    e.transform.position = new Vector3(12.18f, -3, 0);
                }
            }
                yield return new WaitForSeconds(spawnTime);
        }
    }
    private void NextRound()
    {
        if (spawnTime > 2)
        {
            spawnTime -= 1;
        }
    }
}
