using UnityEngine;
using UnityEngine.UI;
using Utage;
using System.Collections;
using System.Collections.Generic;

public class KaguyaUguiConfig : UtageUguiConfig
{

    public AudioSource audiosource;


    /// <summary>「文字送り音」の音量スライダー</summary>
    [SerializeField]
    protected Slider sliderSendcharVolume;

    public override void Close()
    {
        ChangeSendcharVolume(sliderSendcharVolume.value);
        base.Close();
    }

    protected override void LoadValues()
    {
        isInit = false;
        if (checkFullscreen) checkFullscreen.isOn = Config.IsFullScreen;
        if (checkMouseWheel) checkMouseWheel.isOn = Config.IsMouseWheelSendMessage;
        if (checkSkipUnread) checkSkipUnread.isOn = Config.IsSkipUnread;
        if (checkStopSkipInSelection) checkStopSkipInSelection.isOn = Config.IsStopSkipInSelection;
        if (checkHideMessageWindowOnPlyaingVoice) checkHideMessageWindowOnPlyaingVoice.isOn = Config.HideMessageWindowOnPlayingVoice;

        if (sliderMessageSpeed) sliderMessageSpeed.value = Config.MessageSpeed;
        if (sliderMessageSpeedRead) sliderMessageSpeedRead.value = Config.MessageSpeedRead;

        if (sliderAutoBrPageSpeed) sliderAutoBrPageSpeed.value = Config.AutoBrPageSpeed;
        if (sliderMessageWindowTransparency) sliderMessageWindowTransparency.value = Config.MessageWindowTransparency;
        if (sliderSoundMasterVolume) sliderSoundMasterVolume.value = Config.SoundMasterVolume;
        if (sliderBgmVolume) sliderBgmVolume.value = Config.BgmVolume;
        if (sliderSeVolume) sliderSeVolume.value = Config.SeVolume;
        if (sliderAmbienceVolume) sliderAmbienceVolume.value = Config.AmbienceVolume;
        if (sliderVoiceVolume) sliderVoiceVolume.value = Config.VoiceVolume;

        if (radioButtonsVoiceStopType) radioButtonsVoiceStopType.CurrentIndex = (int)Config.VoiceStopType;

        if (sliderSendcharVolume) sliderSendcharVolume.value = audiosource.volume;


        //サブマスターボリュームの設定
        foreach (var item in tagedMasterVolumSliders)
        {
            if (string.IsNullOrEmpty(item.tag) || item.volumeSlider == null)
            {
                continue;
            }

            float volume;
            if (Config.TryGetTaggedMasterVolume(item.tag, out volume))
            {
                item.volumeSlider.value = volume;
            }
        }

        //フルスクリーンはPC版のみの操作
        if (!UtageToolKit.IsPlatformStandAloneOrEditor())
        {
            if (checkFullscreen) checkFullscreen.gameObject.SetActive(false);
            //マウスホイールはPC版とWebGL以外では無効
            if (Application.platform != RuntimePlatform.WebGLPlayer)
            {
                if (checkMouseWheel) checkMouseWheel.gameObject.SetActive(false);
            }
        }
        isInit = true;
    }

    public void ChangeSendcharVolume(float volume)
    {
        audiosource.volume = volume;
    }


}
