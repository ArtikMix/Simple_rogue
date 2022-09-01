using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemies", order = 1)]
public class EnemyController : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private string color;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
}
