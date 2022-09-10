using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] public EnemyController controller;

    //сделать свойства
    public Color color;
    public float speed = 5f;
    private bool canDamage = true;
    [HideInInspector] public int hp = 2;

    private bool isPlayerInRoom = true;//не забыть сделать false
    private Transform player;
    private bool dead = false;

    [SerializeField] private GameObject rip;

    private RoomController roomController;

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

        roomController = FindObjectOfType<RoomController>();
    }

    private void FixedUpdate()
    {
        if (isPlayerInRoom && Vector3.Distance(transform.position, player.position) >= 1.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, player.position) < 1.5f && canDamage)
        {
            StartCoroutine(DoDamage());
        }
    }

    public void TakeDamage()
    {
        Debug.Log(transform.name + " is taking damage!");
        hp--;
        StartCoroutine(TakeDMG());
        if (hp <= 0)
        {
            Death();
        }
    }

    private IEnumerator TakeDMG()
    {
        Color temp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = temp;
    }

    private void Death()
    {
        dead = true;
        Instantiate(rip, transform.position, Quaternion.identity);
        roomController.CheckCondition();
        Destroy(gameObject);
    }

    private IEnumerator DoDamage()
    {
        canDamage = false;
        player.GetComponent<PlayerController>().Damage();
        yield return new WaitForSeconds(1f);
        canDamage = true;
    }
}
