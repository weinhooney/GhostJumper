using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    public override bool Init()
    {
        if (false == base.Init()) { return false; }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        SceneType = Define.EScene.TitleScene;

        return true;
    }

    public override void Clear()
    {

    }
}
