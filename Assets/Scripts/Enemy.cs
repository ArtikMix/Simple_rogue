using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] public EnemyController controller;

    //сделать свойства
    public string name;
    public string color;
    public float speed = 5f;
    public int damage;
    public int hp;

    private bool isPlayerInRoom = true;//не забыть сделать false
    private Transform player;
    private bool dead = false;

    public bool Dead
    {
        get { return dead; }
        set { dead = value; }
    }

    public bool IsPlayerInRoom
    {
        get { return isPlayerInRoom; }
        set { isPlayerInRoom = value; }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //if (isPlayerInRoom && Vector3.Distance(transform.position, player.position) >= 0.1f)
        //{
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}
    }
}
