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

    public void Parametrs(int enemiesC, int[] w, bool prom)
    {
        enemiesCount = enemiesC;
        ways = w;
        promotion = prom;
        //Debug.Log(enemiesC + "\n" + w + "\n" + prom);
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

    private void PortalsActivate()
    {
        for (int i = 0; i < ways.Length; i++)
        {
            portals[i].SetActive(true);
        }
    }
}
