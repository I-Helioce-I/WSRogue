using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum DoorPosition
{
    Top,
    Left,
    Down,
    Right,
    Length
}


public class LevelGenerator : MonoBehaviour
{
    [Header("GenerationRules")]
    [SerializeField] int maxRoomNumber = 5;

    // Corridors
    [SerializeField] Corridor[] corridorsTypes;
    [SerializeField] List<Corridor> inGameCorridors = new List<Corridor>();

    //Rooms
    [SerializeField] Room[] roomsTypes;
    [SerializeField] List<Room> inGameRooms = new List<Room>();

    [SerializeField] GameObject currentInstantiation;


    private void Awake()
    {
        CreateARoom(0);

    }

    private void Start()
    {

    }

    private void InstantiateLevel()
    {
        for (int i = 0; i < maxRoomNumber; i++)
        {
            // Get a randomdoor
            

        }
        // Select a Door

        // Change the door by a door
        // Create 
    }

    private void GetRandomDoor()
    {
        DoorPosition doorPosition = (DoorPosition)Random.RandomRange(0, (int)DoorPosition.Length);
    }

    private void CreateARoom(int ifSpecificRoom)
    {
        int roomToCreate;
        if (ifSpecificRoom >= 0)
        {
            roomToCreate = ifSpecificRoom;
        }
        else
        {
            roomToCreate = Random.Range(0, roomsTypes.Length);
        }

        currentInstantiation = Instantiate(roomsTypes[roomToCreate], transform).gameObject;
        currentInstantiation.transform.position = transform.position;

    }

    private void CreateACorridor()
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
