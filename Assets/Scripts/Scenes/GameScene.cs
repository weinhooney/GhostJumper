using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class GameScene : BaseScene
{
    public override bool Init()
    {
        if (false == base.Init()) { return false; }

        SceneType = Define.EScene.GameScene;

        return true;
    }

    public override void Clear()
    {

    }
}
