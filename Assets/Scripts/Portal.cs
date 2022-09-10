using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int way;
    private RoomController controller;

    private void Start()
    {
        controller = FindObjectOfType<RoomController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            controller.Teleportation(way);
        }
    }
}
