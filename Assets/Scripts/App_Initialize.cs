using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App_Initialize : MonoBehaviour
{
    void Awake()
    {
        Shader.SetGlobalFloat("_Curvature", 2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
        Application.targetFrameRate = 60;
    }
}
