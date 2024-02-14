using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CrosshairMouse : MonoBehaviour
{
    [SerializeField] public Vector3 screenPosition;
    public Image crosshair;
    public Vector3 offset;
    public float offsetZ;
    public new Camera camera;

    private void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Mouse.current.position.ReadValue();
        crosshair.GetComponent<RectTransform>().anchoredPosition = screenPosition;
    }
}
