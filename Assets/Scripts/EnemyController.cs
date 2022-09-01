using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class EnemyController : ScriptableObject
{
    public string name;
    public string color;
    public float speed;
    public int damage;
    public int hp;
}
