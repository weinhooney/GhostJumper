using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    public enum EScene
    {
        Unknown,
        TitleScene,
        GameScene,
    }

    public enum EUIEvent
    {
        Click,
        PointerDown,
        PointerUp,
        Drag,
    }

    public enum EJoystickState
    {
        PointerDown,
        PointerUp,
        Drag
    }

    public enum ESound
    {
        Bgm,
        Effect,
        Max,
    }

    public enum ELayer
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        Dummy1 = 3,
        Water = 4,
        UI = 5,
        Hero = 6,
        Monster = 7,
        Env = 8,
        Obstacle = 9,
        Projectile = 10,
    }
    
    public enum EState
    {
        None,
        Idle,
        Die,
        Run,
        Jump,
    }
}

public static class AnimName
{
    //public const string ATTACK_A = "attack";
    public const string IDLE = "idle";
    public const string RUN = "run";
    public const string JUMP1 = "jump";
}

public static class SortingLayers
{
    //public const int SPELL_INDICATOR = 200;
}
