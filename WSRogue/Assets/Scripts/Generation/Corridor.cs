using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CorridorType
{
    Horizontal,
    Vertical
}

public class Corridor : MonoBehaviour
{
    [SerializeField] CorridorType actualCorridor;
    [SerializeField] List<Door> doors = new List<Door>();


}
