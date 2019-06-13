// UTAGE: Unity Text Adventure Game Engine (c) Ryohei Tokimura
using UnityEngine;
using Utage;
using System.Collections;


/// <summary>
/// タイトル表示のサンプル
/// </summary>
[AddComponentMenu("Utage/TemplateUI/Title")]
public class KaguyaUguiTitle : UtageUguiTitle
{

    /// <summary>ExternalEffectController</summary>
    public GameObject eec;

    protected override void OnOpen()
    {
        eec.GetComponent<ExternalEffectController>().InitializeEffects();
        config.GetComponent<KaguyaUguiConfig>().ChangeSendcharVolume(0.25f);

        //      if (Starter != null && Starter.enabled != AdvEngineStarter.ScenarioLoadType.Server)
        {
            if (downloadButton != null)
            {
                downloadButton.SetActive(false);
            }
        }
    }

    public virtual void OnTapExit()
    {
        Close();
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }



}
