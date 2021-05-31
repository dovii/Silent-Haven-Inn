using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using UnityEngine.Experimental.Rendering.Universal;



public class SetElfCandle : MonoBehaviour
{
    
    public Light2D myLight;
    int candlestate;
    public string varName;
    
    void Start()
    {
        myLight = GetComponent<Light2D>();     
    }

    void Update()
    {
        candlestate = DialogueLua.GetVariable(varName).asInt;
        if (candlestate == 0)
        {
            myLight.intensity = 0.4f;
        }
        else if(candlestate == 1)
        {
            myLight.intensity = 0.8f;
        }
        else if (candlestate == 2)
        {
            myLight.intensity = 1.2f;
        }

        Debug.Log(candlestate);

    }


}
