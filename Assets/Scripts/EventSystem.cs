using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public delegate void WallHitHandler(WallHitArgs wallHitArgs);
    public delegate void JumpHandler(JumpArgs playerJumpArgs);
    public static event WallHitHandler BeforeNextLevel;
    public static event WallHitHandler NextLevel;
    public static event JumpHandler Jump;
    public static event JumpHandler AnimateJump;
    public class WallHitArgs
    {
        public bool isRightWall;
        public WallHitArgs(bool isRightWall)
        {
            this.isRightWall = isRightWall;
        }
    }
    public class JumpArgs
    {
        public JumpArgs()
        {

        }
    }
    public static void OnWallHit(WallHitArgs wallHitArgs)
    {
        BeforeNextLevel(wallHitArgs);
        NextLevel(wallHitArgs);
    }
    public static void OnJump(JumpArgs jumpArgs)
    {
        Jump(jumpArgs);
        AnimateJump(jumpArgs);
    }
    public static void OnAnimateJump(JumpArgs jumpArgs)
    {
        AnimateJump(jumpArgs);
    }
}
