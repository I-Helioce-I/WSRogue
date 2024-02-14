using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    NotSet,
    Hole,
    Door,
    Wall
}

public class Door : MonoBehaviour
{
    [SerializeField] Door thisDoor;
    [SerializeField] DoorPosition currentPosition;
    [SerializeField] DoorType currentDoorType;
    [SerializeField] bool isOpen;
    [SerializeField] bool isADoor;
    [SerializeField] GameObject relativeWall;

    [SerializeField] GameObject doorPrefab;
    [SerializeField] GameObject wallPrefab;
    
    public DoorPosition GetActualPosition()
    {
        return currentPosition;
    }

    private void Awake()
    {
        thisDoor = this;
        CheckDoorAndWall();
    }

    private void CheckDoorAndWall()
    {
        switch (currentDoorType)
        {
            case DoorType.Hole:
                relativeWall.SetActive(false);
                break;
            case DoorType.Door:
                //doorPrefab.SetActive(true);
                break;
            case DoorType.Wall:
                //wallPrefab.SetActive(true);
                break;
            default:
                break;
        }
    }
}
