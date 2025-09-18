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
    GiantEnemy giantEnemy;
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
            else
            {
                int chooseEnemy = Random.Range(0, 8);
                switch (chooseEnemy)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        Enemy e = Instantiate(enemy);
                        e.transform.position = new Vector3(12.18f, -3, 0);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        JumpingEnemy e2 = Instantiate(jumpingEnemy);
                        e2.transform.position = new Vector3(12.18f, -3, 0);
                        break;
                    case 7:
                        GiantEnemy e3 = Instantiate(giantEnemy);
                        e3.transform.position = new Vector3(12.18f, -3, 0);
                        break;
                         
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
