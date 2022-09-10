using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();

    [SerializeField] private int enemiesCount;
    [SerializeField] private int[] ways;
    [SerializeField] private bool promotion;
    [SerializeField] private GameObject[] portals = new GameObject[3];

    [SerializeField] private GameObject baseEnemy;
    [SerializeField] private GameObject enemiesContainer;

    public void Parametrs(int enemiesC, int[] w, bool prom)
    {
        enemiesCount = enemiesC;
        ways = w;
        promotion = prom;
        SpawnEnemies();
        //Debug.Log(enemiesC + "\n" + w + "\n" + prom);
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i<enemiesCount; i++)
        {
            Instantiate(baseEnemy, new Vector2(Random.Range(transform.position.x / 1.9f, transform.position.x * 1.9f), Random.Range(transform.position.y / 1.9f, transform.position.y
                * 1.9f)), Quaternion.identity, enemiesContainer.transform);
        }
    }

    public bool CheckEnemiesCondition()
    {
        int murders = 0;

        foreach(Enemy e in enemies)
        {
            if (e.Dead)
            {
                murders++;
            }
        }

        if (murders == enemies.Count)
        {
            return true;
        }
        else return false;
    }

    public void PortalsActivate()
    {
        for (int i = 0; i < ways.Length; i++)
        {
            portals[i].SetActive(true);
            portals[i].GetComponent<Portal>().way = ways[i];
        }
    }
}
