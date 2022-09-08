using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();

    [SerializeField] private int enemiesCount;
    [SerializeField] private int[] ways;
    [SerializeField] private bool promotion;

    public void Parametrs(int enemiesC, int[] w, bool prom)
    {
        enemiesCount = enemiesC;
        ways = w;
        promotion = prom;
        //Debug.Log(enemiesC + "\n" + w + "\n" + prom);
    }
}
