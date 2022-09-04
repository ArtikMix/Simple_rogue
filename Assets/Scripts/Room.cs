using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<Enemy> enemies = new List<Enemy>();

    private int enemiesCount;
    private int[] ways;

    public void GetParametrs(int ec, int[] w)
    {
        enemiesCount = ec;
        ways = w;
        SetParametrs();
    }

    private void SetParametrs()
    {

    }
}
