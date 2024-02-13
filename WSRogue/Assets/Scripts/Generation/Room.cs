using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum RoomType
{
    Arena,
    Shop,
    Fountain,
    Boss,
    HCorridor,
    VCorridor
}

public class Room : MonoBehaviour
{
    [SerializeField] List<Door> doors = new List<Door>();
    [SerializeField] RoomType roomType;
    [SerializeField] Door doorSelected;
    [SerializeField] Door oppositeDoor;
    [SerializeField] Vector3 size;

    public Door GetRandomDoor(int doorToIgnore)
    {
        List<Door> doorPossible = new List<Door>();
        DoorPosition doorPosition = (DoorPosition)Random.Range(0, (int)DoorPosition.Length-1);

        


        foreach (Door door in doors)
        {
            if (door.GetActualPosition() == doorPosition)
            {
                doorPossible.Add(door);
            }
        }

        int doorSelected = Random.Range(0, doorPossible.Count);
        return doorPossible[doorSelected];
    }
    

    public Door GetOppositeDoor(DoorPosition doorIn)
    {
        Debug.Log(doorIn);
        DoorPosition oppositeDirection = DoorPosition.Length;

        if (doorIn == DoorPosition.Top)
        {
            oppositeDirection = DoorPosition.Down;
        }
        else if (doorIn == DoorPosition.Down)
        {
            oppositeDirection = DoorPosition.Top;
        }
        else if (doorIn == DoorPosition.Left)
        {
            oppositeDirection = DoorPosition.Right;
        }
        else if (doorIn == DoorPosition.Right)
        {
            oppositeDirection = DoorPosition.Left;
        }

        List<Door> possibleDoor = new List<Door>();

        foreach (Door door in doors)
        {
            if (door.GetActualPosition() == oppositeDirection && oppositeDirection != DoorPosition.Length)
            {
                possibleDoor.Add(door);
            }
        }

        int doorSelected = Random.Range(0, possibleDoor.Count);

        Debug.Log("Door length " + possibleDoor.Count);

        return possibleDoor[doorSelected];
    }

    public void RemoveInList(Door door)
    {
        doors.Remove(door);
    }

    public Vector3 GetSize()
    {
        return size;
    }
}
