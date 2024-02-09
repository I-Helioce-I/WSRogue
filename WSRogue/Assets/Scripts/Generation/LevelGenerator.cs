using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorPosition
{
    Top,
    Left,
    Down,
    Right
}


public class LevelGenerator : MonoBehaviour
{
    // Corridors
    [SerializeField] Corridor[] corridorsTypes;
    [SerializeField] List<Corridor> inGameCorridors = new List<Corridor>();

    //Rooms
    [SerializeField] Room[] roomsTypes;
    [SerializeField] List<Room> inGameRooms = new List<Room>();

    [SerializeField] 


    private void Awake()
    {
        Corridor currentCorridor = Instantiate(GetRandomCorridor(), transform);
        currentCorridor.transform.position = Vector3.zero;
        inGameCorridors.Add(currentCorridor);
    }

    private void Start()
    {
        
    }

    

    private Corridor GetRandomCorridor()
    {
        int randomInt = Random.Range(0, corridorsTypes.Length);

        return corridorsTypes[randomInt];
    }

    private Room GetRandomRoom()
    {
        int randomInt = Random.Range(0, roomsTypes.Length);

        return roomsTypes[randomInt];
    }


}
