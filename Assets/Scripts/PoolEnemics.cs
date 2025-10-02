using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolEnemics : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private JumpingEnemy jumpingEnemy;
    [SerializeField]
    private GiantEnemy giantEnemy;
    private GiantEnemy boss;
    private List<Enemy> enemyList;
    private List<JumpingEnemy> jumpingEnemyList;
    [SerializeField]
    private GameManager gameManager;
    private bool bossActive;
    [SerializeField]
    private int spawnTime;
    private void Awake()
    {
        enemyList = new List<Enemy>();
        jumpingEnemyList = new List<JumpingEnemy>();
        bossActive = false;
        spawnTime = 3;
        gameManager.changeRound += NextRound;
        InitPool();
    }
    private void Start()
    {
        StartCoroutine(Spawn());
        boss = Instantiate(giantEnemy);
        boss.gameObject.SetActive(false);
    }
    private void InitPool()
    {
        for(int i = 0; i < 10; i++)
        {
            Enemy e = Instantiate(enemy);
            e.gameObject.SetActive(false);
            enemyList.Add(e);
            JumpingEnemy je = Instantiate(jumpingEnemy);
            je.gameObject.SetActive(false);
            jumpingEnemyList.Add(je);
        }
        
    }

    private Enemy GetPoolEnemy()
    {
        for (int i = 0; i < enemyList.Count;i++)
        {
            if (!enemyList.ElementAt(i).isActiveAndEnabled)
            {
                enemyList.ElementAt(i).gameObject.SetActive(true);
                return enemyList[i];
            }
        }
        return null;
    }
    private JumpingEnemy GetPoolJumpingEnemy()
    {
        for (int i = 0; i < jumpingEnemyList.Count; i++)
        {
            if (!jumpingEnemyList.ElementAt(i).isActiveAndEnabled)
            {
                jumpingEnemyList.ElementAt(i).gameObject.SetActive(true);
                return jumpingEnemyList[i];
            }
        }
        return null;
    }
    private GiantEnemy GetPoolGiantEnemy()
    {
        return boss;
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            if (gameManager.round < 2)
            {
                Enemy e = GetPoolEnemy();
                e.transform.position = new Vector3(12.18f, -3, 0);
            }
            else if (gameManager.round < 3)
            {
                int chooseEnemy = Random.Range(0, 2);
                if (chooseEnemy == 0)
                {
                    Enemy e = GetPoolEnemy();
                    e.transform.position = new Vector3(12.18f, -3, 0);
                }
                else
                {
                    JumpingEnemy e = GetPoolJumpingEnemy();
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
                        Enemy e = GetPoolEnemy();
                        e.transform.position = new Vector3(12.18f, -3, 0);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        JumpingEnemy e2 = GetPoolJumpingEnemy();
                        e2.transform.position = new Vector3(12.18f, -3, 0);
                        break;
                    case 7:
                        if (!bossActive && gameManager.round >= 3)
                        {
                            GiantEnemy e3 = GetPoolGiantEnemy();
                            e3.transform.position = new Vector3(12.18f, 0, 0);
                            bossActive = true;
                        }
                        else
                        {
                            e = GetPoolEnemy();
                            e.transform.position = new Vector3(12.18f, -3, 0);
                        }
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
    private void OnDestroy()
    {
        gameManager.changeRound -= NextRound;
    }
}
