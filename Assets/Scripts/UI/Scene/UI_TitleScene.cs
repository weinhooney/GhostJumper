using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitleScene : UI_Scene
{
    enum GameObjects
    {
        StartImage,
        UI_LoadingBar,
    }

    enum Texts
    {
        DisplayText
    }

    //UI_LoadingBar _loadingBar;

    public override bool Init()
    {
        if (false == base.Init()) { return false; }

        BindObjects(typeof(GameObjects));
        BindTexts(typeof(Texts));

        GetObject((int)GameObjects.StartImage).BindEvent((evt) => 
        {
            Debug.Log("Change Scene");
            Managers.Scene.LoadScene(Define.EScene.GameScene);
        });

        GetObject((int)GameObjects.StartImage).SetActive(false);
        GetText((int)Texts.DisplayText).text = $"";

        //_loadingBar = GetObject((int)GameObjects.UI_LoadingBar).GetComponent<UI_LoadingBar>();

        StartLoadAssets();

        return true;
    }

    private void StartLoadAssets()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
        {
            Debug.Log($"{key} {count}/{totalCount}");

            //_loadingBar.SetValue(count / (float)totalCount);

            if (count == totalCount)
            {
                //_loadingBar.gameObject.SetActive(false);

                Managers.Data.Init();

                GetObject((int)GameObjects.StartImage).SetActive(true);
                GetText((int)Texts.DisplayText).text = "Touch To Start";
            }
        });
    }
}
