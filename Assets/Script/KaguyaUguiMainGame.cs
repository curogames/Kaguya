using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utage;

public class KaguyaUguiMainGame : UtageUguiMainGame
{

    /// <summary>オプション画面を開くボタン</summary>
    public Toggle checkOption;

    public KaguyaUguiOption option;


    private float pushEndTime;
    private float pushDiffTime;
    private bool IsPush = false;


    //オプションボタンが押された
    public virtual void OnTapOption()
    {
        if (Engine.IsSceneGallery) return;

        StartCoroutine(CoOption());
    }

    protected virtual IEnumerator CoOption()
    {
        if (Engine.SaveManager.Type != AdvSaveManager.SaveType.SavePoint)
        {
            yield return new WaitForEndOfFrame();
            //セーブ用のスクショを撮る
            Engine.SaveManager.CaptureTexture = CaptureScreen();
        }
        //オプション画面開く
        Close();
        option.Open(this);
    }


    protected override void Update()
    {
        if (!isInit) return;

        //ローディングアイコンを表示
        if (SystemUi.GetInstance())
        {
            if (Engine.IsLoading)
            {
                SystemUi.GetInstance().StartIndicator(this);
            }
            else
            {
                SystemUi.GetInstance().StopIndicator(this);
            }
        }


        if (Engine.IsEndScenario)
        {
            Close();
            if (Engine.IsSceneGallery)
            {
                //回想シーン終了したのでギャラリーに
                gallery.Open();
            }
            else
            {
                //シナリオ終了したのでタイトルへ
                title.Open(this);
            }
        }


        if (Input.GetMouseButton(0))
        {
            if (!IsPush)
            {
                pushEndTime = Time.time + 2.0f;
                IsPush = true;
            }
            else
            {
                pushDiffTime = pushEndTime - Time.time;
                if (pushDiffTime <= 0 && !Engine.Config.IsSkip)
                {
                    OnTapSkip(true);
                }
            }


        }
        else
        {
            if (Engine.Config.IsSkip)
            {
                Engine.Config.IsSkip = false;
            }
            IsPush = false;
        }


    }



}
