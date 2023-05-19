using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HideMouse();
    }

    private void HideMouse() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
