using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using UB;

[AddComponentMenu("Utage/ADV/Examples/SendMessageByName")]
public class FogController : MonoBehaviour
{
    private GameObject child;
    private D2FogsPE d2fogpe;
 
    // Start is called before the first frame update
    void Start()
    {
 
        child = transform.GetChild(0).gameObject;
        d2fogpe = GetComponent<D2FogsPE>();

    }

    // Update is called once per frame
    void DisableFog(AdvCommandSendMessageByName command)
    {
        child.GetComponent<D2FogsPE>().enabled = false;
    }

    void EnableFog(AdvCommandSendMessageByName command)
    {
        child.GetComponent<D2FogsPE>().enabled = true;
        //Debug.Log("success enable fog");
    }

    void ModifyFogColor(AdvCommandSendMessageByName command)
    {
        float r = command.ParseCellOptional<float>(AdvColumnName.Arg3, 0f);
        float g = command.ParseCellOptional<float>(AdvColumnName.Arg4, 0f);
        float b = command.ParseCellOptional<float>(AdvColumnName.Arg5, 0f);
        float a = command.ParseCellOptional<float>(AdvColumnName.Arg6, 1f);
        Color c = new Color(r, g, b, a);
        child.GetComponent<D2FogsPE>().Color = c;
        //Debug.Log("success size color");
    }

    void ModifyFogSize(AdvCommandSendMessageByName command)
    {
        float size = command.ParseCellOptional<float>(AdvColumnName.Arg3, 1f);
        child.GetComponent<D2FogsPE>().Size = size;
        //Debug.Log("success size change");
    }

    public void InitializeFog()
    {
        if(d2fogpe != null)
        {
            d2fogpe.enabled = false;
        }

    }


}
