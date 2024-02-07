using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorFight;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.SetCursor(cursorFight,Vector2.zero,CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
