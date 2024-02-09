using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Door thisDoor;
    [SerializeField] DoorPosition currentPosition;
    [SerializeField] bool isOpen;
    [SerializeField] bool isADoor;
    public DoorPosition ActualDoorPosition { get; private set; }



    private void Awake()
    {
        thisDoor = this;

    }

}
