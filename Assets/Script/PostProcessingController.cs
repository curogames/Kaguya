using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using Utage;

[AddComponentMenu("Utage/ADV/Examples/SendMessageByName")]
public class PostProcessingController : MonoBehaviour
{
    private GameObject child;
    private PostProcessingBehaviour postbehaviour;
    private BloomModel.Settings bloomsetting;
    private VignetteModel.Settings vignettesetting;
    private GrainModel.Settings grainsetting;

    // Start is called before the first frame update
    void Awake()
    {
        child = transform.GetChild(0).gameObject;
        postbehaviour = child.GetComponent<PostProcessingBehaviour>();
        if(postbehaviour == null)
        {
            Debug.Log("E001 postbehaviour is null");
        }
        else
        {
            Debug.Log("I001 posteffectcontroller is Loaded");
        }
        bloomsetting = postbehaviour.profile.bloom.settings;
        vignettesetting = postbehaviour.profile.vignette.settings;
        grainsetting = postbehaviour.profile.grain.settings;
    }

    // Update is called once per frame
    void Update()
    {
            postbehaviour.profile.bloom.settings = bloomsetting;
            postbehaviour.profile.vignette.settings = vignettesetting;
            postbehaviour.profile.grain.settings = grainsetting;
    }

    public void EnableBloom()
    {

        postbehaviour.profile.bloom.enabled = true;

    }

    public void DisableBloom()
    {

        postbehaviour.profile.bloom.enabled = false;

    }

    public void BloomIntensity(float param, float time)
    {
        float diff = bloomsetting.bloom.intensity - param;
        StartCoroutine(CoBloomIntensity(param, bloomsetting.bloom.intensity, diff, time));
    }

    IEnumerator CoBloomIntensity(float param, float start, float diff, float time)
    {
        float endtime = Time.time + time;

        while (true)
        {
            float timediff = endtime - Time.time;

            if(timediff <= 0)
            {
                break;
            }
            float rate = (1 - Mathf.Clamp01(timediff / time));
            float delta = diff * rate;
            bloomsetting.bloom.intensity = start - delta;
            yield return null;
        }
       
        bloomsetting.bloom.intensity = param;

    }



    public void EnableVignette()
    {
        postbehaviour.profile.vignette.enabled = true;
    }

    public void DisableVignette()
    {
        postbehaviour.profile.vignette.enabled = false;
    }

    public void VignetteIntensity(float param, float time)
    {
        float diff = vignettesetting.intensity - param;
        StartCoroutine(CoVignetteIntensity(param, vignettesetting.intensity, diff, time));
    }

    IEnumerator CoVignetteIntensity(float param, float start, float diff, float time)
    {
        float endtime = Time.time + time;

        while (true)
        {
            float timediff = endtime - Time.time;

            if (timediff <= 0)
            {
                break;
            }
            float rate = (1 - Mathf.Clamp01(timediff / time));
            float delta = diff * rate;
            vignettesetting.intensity = start - delta;
            yield return null;
        }

        vignettesetting.intensity = param;

    }

    public void VignetteSmoothness(float param, float time)
    {
        float diff = vignettesetting.smoothness - param;
        StartCoroutine(CoVignetteSmoothness(param, vignettesetting.smoothness, diff, time));
    }

    IEnumerator CoVignetteSmoothness(float param, float start, float diff, float time)
    {
        float endtime = Time.time + time;

        while (true)
        {
            float timediff = endtime - Time.time;

            if (timediff <= 0)
            {
                break;
            }
            float rate = (1 - Mathf.Clamp01(timediff / time));
            float delta = diff * rate;
            vignettesetting.smoothness = start - delta;
            yield return null;
        }

        vignettesetting.smoothness = param;
    }

    public void VignetteRoundness(float param, float time)
    {
        float diff = vignettesetting.roundness - param;
        StartCoroutine(CoVignetteRoundness(param, vignettesetting.roundness, diff, time));
    }

    IEnumerator CoVignetteRoundness(float param, float start, float diff, float time)
    {
        float endtime = Time.time + time;

        while (true)
        {
            float timediff = endtime - Time.time;

            if (timediff <= 0)
            {
                break;
            }
            float rate = (1 - Mathf.Clamp01(timediff / time));
            float delta = diff * rate;
            vignettesetting.roundness = start - delta;
            yield return null;
        }

        vignettesetting.roundness = param;
    }


    /// <summary>Grain</summary>

    public void EnableGrain()
    {

        postbehaviour.profile.grain.enabled = true;

    }

    public void DisableGrain()
    {

        postbehaviour.profile.grain.enabled = false;

    }


    public void GrainIntensity(float param, float time)
    {
        float diff = grainsetting.intensity - param;
        StartCoroutine(CoGrainIntensity(param, grainsetting.intensity, diff, time));
    }

    IEnumerator CoGrainIntensity(float param, float start, float diff, float time)
    {
        float endtime = Time.time + time;

        while (true)
        {
            float timediff = endtime - Time.time;

            if (timediff <= 0)
            {
                break;
            }
            float rate = (1 - Mathf.Clamp01(timediff / time));
            float delta = diff * rate;
            grainsetting.intensity = start - delta;
            yield return null;
        }

        grainsetting.intensity = param;
    }


    public void InitializeProfile()
    {
        bloomsetting.bloom.intensity = 0.5f;
        bloomsetting.bloom.threshold = 1.1f;
        bloomsetting.bloom.softKnee = 0.5f;
        bloomsetting.bloom.radius = 4f;
        bloomsetting.bloom.softKnee = 0.5f;
        postbehaviour.profile.bloom.enabled = false;

        vignettesetting.mode = VignetteModel.Mode.Classic;
        vignettesetting.intensity = 0.45f;
        vignettesetting.smoothness = 0.2f;
        vignettesetting.roundness = 1.0f;
        vignettesetting.rounded = false;
        postbehaviour.profile.vignette.enabled = false;

        grainsetting.intensity = 0.5f;
        postbehaviour.profile.grain.enabled = false;

    }






}