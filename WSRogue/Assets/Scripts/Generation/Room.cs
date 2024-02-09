using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RoomType
{
    Arena,
    Shop,
    Fountain,
    Boss

}

public class Room : MonoBehaviour
{
    [SerializeField] List<Door> doors = new List<Door>();
    [SerializeField] RoomType roomType;
}
