using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class OneWayPlatform : MonoBehaviour
{
    [Header("Script de base fait par Thomas GODDARD")]

    [SerializeField] private MeshCollider collision;
    [SerializeField] public GameObject player;
    private bool isCheckingCollision = true;

    [SerializeField] private LayerMask nullLayer;
    [SerializeField] private LayerMask playerLayer;

    private void Awake()
    {
        collision = GetComponent<MeshCollider>();
    }

    public bool IsCheckingPosition
    {
        get => isCheckingCollision;
        set => isCheckingCollision = value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCheckingCollision)
        {
            if (player != null)
            {
                // var playerPosY = get Player position.y
                var playerPosY = player.transform.position.y;
                //check playerPosY par rapport a la positon de la platform ( world position Y ) 
                // Si supérieur => Activer collisions
                // Else desactiver

                if (playerPosY >= gameObject.transform.position.y)
                {
                    collision.excludeLayers = playerLayer;
                }
                else
                {
                    collision.excludeLayers = nullLayer;
                }
            }

        }
    }

    void EnableCollision()
    {
        collision.excludeLayers = nullLayer;
    }

    void DisableCollision()
    {
        collision.excludeLayers = playerLayer;
    }
}
