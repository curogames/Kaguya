using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utage;

[AddComponentMenu("Utage/ADV/Examples/UtageRecieveMessageSample")]
public class ReceiveMessage : MonoBehaviour
{
    public AdvEngine engine;

    public GameObject screeneffectcamera;
    public GameObject fogcamera;

    public GameObject uimanager;

    private PostProcessingController sfcppc;
    private FogController fc;

    private KaguyaUguiManager kumgr;

    void Start()
    {
        sfcppc = screeneffectcamera.GetComponent<PostProcessingController>();
        fc = fogcamera.GetComponent<FogController>();

        kumgr = uimanager.GetComponent<KaguyaUguiManager>();
    }


    void OnDoCommand(AdvCommandSendMessage command)
    {
        switch (command.Name)
        {
            case "DebugLog":
                DebugLog(command);
                break;

            case "InitializeProfile":
                InitializeProfile(command);
                break;

            case "EnableBloom":
                EnableBloom(command);
                break;
            case "DisableBloom":
                DisableBloom(command);
                break;
            case "BloomIntensity":
                BloomIntensity(command);
                break;

            case "EnableVignette":
                EnableVignette(command);
                break;
            case "DisableVignette":
                DisableVignette(command);
                break;
            case "VignetteIntensity":
                VignetteIntensity(command);
                break;
            case "VignetteSmoothness":
                VignetteSmoothness(command);
                break;
            case "VignetteRoundness":
                VignetteRoundness(command);
                break;

            case "EnableGrain":
                EnableGrain(command);
                break;
            case "DisableGrain":
                DisableGrain(command);
                break;
            case "GrainIntensity":
                GrainIntensity(command);
                break;

            case "EnableSendCharSE":
                EnableSendCharSE(command);
                break;
            case "DisableSendCharSE":
                DisableSendCharSE(command);
                break;

            default:
                Debug.Log("E03: Unknown Message:" + command.Name);
                break;
        }

    }

    void DebugLog(AdvCommandSendMessage command)
    {
        Debug.Log(sfcppc);
    }


    //PostEffect
    void InitializeProfile(AdvCommandSendMessage command)
    {
        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.InitializeProfile();
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }



    //PostEffect Bloom

    void EnableBloom(AdvCommandSendMessage command)
    {
        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.EnableBloom();
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    void DisableBloom(AdvCommandSendMessage command)
    {
        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.DisableBloom();
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    void BloomIntensity(AdvCommandSendMessage command)
    {
        float param = float.Parse(command.Arg3);
        float time = float.Parse(command.Arg4);

        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.BloomIntensity(param, time);
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }


    //PostEffect Vignette

    void EnableVignette(AdvCommandSendMessage command)
    {
        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.EnableVignette();
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    void DisableVignette(AdvCommandSendMessage command)
    {
        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.DisableVignette();
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    void VignetteIntensity(AdvCommandSendMessage command)
    {
        float param = float.Parse(command.Arg3);
        float time = float.Parse(command.Arg4);

        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.VignetteIntensity(param, time);
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    void VignetteSmoothness(AdvCommandSendMessage command)
    {
        float param = float.Parse(command.Arg3);
        float time = float.Parse(command.Arg4);

        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.VignetteSmoothness(param, time);
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    void VignetteRoundness(AdvCommandSendMessage command)
    {
        float param = float.Parse(command.Arg3);
        float time = float.Parse(command.Arg4);

        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.VignetteRoundness(param, time);
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }


    //PostEffect Grain

    void EnableGrain(AdvCommandSendMessage command)
    {
        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.EnableGrain();
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    void DisableGrain(AdvCommandSendMessage command)
    {
        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.DisableGrain();
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    void GrainIntensity(AdvCommandSendMessage command)
    {
        float param = float.Parse(command.Arg3);
        float time = float.Parse(command.Arg4);

        switch (command.Arg2)
        {
            case "ScreenEffectCamera":
                sfcppc.GrainIntensity(param, time);
                break;
            default:
                Debug.Log("E04: Unknown Object:" + command.Arg2);
                break;
        }
    }

    //文字送り音

    void EnableSendCharSE(AdvCommandSendMessage command)
    {
        kumgr.EnableSendCharSE();
    }

    void DisableSendCharSE(AdvCommandSendMessage command)
    {
        kumgr.DisableSendCharSE();
    }




}
