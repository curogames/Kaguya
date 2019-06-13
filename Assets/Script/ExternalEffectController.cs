using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalEffectController : MonoBehaviour
{
    public GameObject screeneffectcamera;
    public GameObject fogcamera;

    private PostProcessingController sfcppc;
    private FogController fc;


    // Start is called before the first frame update
    void Start()
    {
        sfcppc = screeneffectcamera.GetComponent<PostProcessingController>();
        fc = fogcamera.GetComponent<FogController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeEffects()
    {
        sfcppc.InitializeProfile();
        fc.InitializeFog();
    }

}
