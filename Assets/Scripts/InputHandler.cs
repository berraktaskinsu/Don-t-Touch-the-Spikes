using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EventSystem.JumpArgs jumpArgs = new EventSystem.JumpArgs();
            EventSystem.OnJump(jumpArgs);
        }
    }
}
