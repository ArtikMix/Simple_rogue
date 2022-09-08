using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    private List<Room> rooms = new List<Room>();
    [SerializeField] private GameObject baseRooms;//потом будет массив комнат

    private void Start()
    {
        CreateMap();
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
            GameObject room = Instantiate(baseRooms, spawnPlace, Quaternion.identity);
            rooms.Add(room.GetComponent<Room>());

            bool prom = true;//
            int enemiesCountInRoom = Random.Range(3, 9);
            int[] ways = new int[Random.Range(1,3)];
            for (int j = 0; j < ways.Length; j++)
            {
                ways[j] = Random.Range(0, rooms.Count);
                if (prom)
                {
                    ways[0] = rooms.Count + 1;
                }
            }
            room.GetComponent<Room>().Parametrs(enemiesCountInRoom, ways, prom);

            spawnPlace = new Vector2(spawnPlace.x + 50f, 0);
        }
    }
}
