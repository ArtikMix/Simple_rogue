using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyController controller;
    private bool isPlayerInRoom = false;
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
        //if (isPlayerInRoom && Vector3.Distance(tramsform.position, player.position) >= 1f)
        //{
            transform.position = Vector2.MoveTowards(transform.position, player.position, controller.speed * Time.deltaTime);
        //}
    }
}
