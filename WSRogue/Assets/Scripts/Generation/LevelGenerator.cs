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
    [Header("Corridor")]
    [SerializeField] Room[] corridorsTypes;
    [SerializeField] List<Room> inGameCorridors = new List<Room>();

    //Rooms
    [Header("Room")]
    [SerializeField] Room[] roomsTypes;
    [SerializeField] List<Room> inGameRooms = new List<Room>();

    [SerializeField] Room previousInstantiation;
    [SerializeField] Room currentInstantiation;

    private void Awake()
    {
        InstantiateLevel();
    }
    private void InstantiateLevel()
    {

        currentInstantiation = Instantiate(roomsTypes[0], transform);
        currentInstantiation.transform.position = transform.position;
        previousInstantiation = currentInstantiation;

        for (int r = 0; r < maxRoomNumber; r++)
        {
            int numberOfCorridor = Random.Range(1, 5);
            for (int c = 0; c < numberOfCorridor; c++)
            {
                CreateACorridor();
                previousInstantiation = currentInstantiation;
            }
            CreateARoom(0);
            previousInstantiation = currentInstantiation;
        }
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
        Door previousDoor = previousInstantiation.GetRandomDoor(-1);
        Door nextDoor;

        currentInstantiation = Instantiate(GetRandomCorridor(), transform);

        nextDoor = currentInstantiation.GetOppositeDoor(previousDoor.GetActualPosition());

        Vector3 offset = nextDoor.transform.localPosition;

        currentInstantiation.transform.position = previousDoor.transform.position;
        currentInstantiation.transform.position -= offset;

        //previousInstantiation.RemoveInList(previousDoor);
        //currentInstantiation.RemoveInList(nextDoor);

        //Destroy(previousDoor.gameObject);
        //Destroy(nextDoor.gameObject);
    }

    private void CreateACorridor()
    {
        Door previousDoor = previousInstantiation.GetRandomDoor(-1);
        Door nextDoor;

        currentInstantiation = Instantiate(GetRandomCorridor(), transform);

        nextDoor = currentInstantiation.GetOppositeDoor(previousDoor.GetActualPosition());

        Vector3 offset = nextDoor.transform.localPosition;

        currentInstantiation.transform.position = previousDoor.transform.position;
        currentInstantiation.transform.position -= offset;

        //previousInstantiation.RemoveInList(previousDoor);
        //currentInstantiation.RemoveInList(nextDoor);

        //Destroy(previousDoor.gameObject);
        //Destroy(nextDoor.gameObject);
    }

    private Room GetRandomCorridor()
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
