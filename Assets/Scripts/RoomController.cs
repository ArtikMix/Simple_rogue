using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private List<Room> rooms = new List<Room>();
    [SerializeField] private GameObject[] baseRooms = new GameObject[3];

    private void Start()
    {
        
    }

    private void CreateMap()
    {
        //базовые значения
        int figthRoomCount = Random.Range(5, 9);
        int upgradeRoomCount = Random.Range(1, 3);
        Vector2 spawnPlace = new Vector2(0, 0);

        //спавн файтрумов
        for (int i = 0; i < figthRoomCount; i++)
        {
            GameObject room = Instantiate(baseRooms[Random.Range(0, 2)], spawnPlace, Quaternion.identity);
            int[] waysForThisRoom = new int[Random.Range(1, 3)];
            room.GetComponent<Room>().GetParametrs(Random.Range(3, 9), waysForThisRoom);
        }
    }
}
