using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [DllImport("EngGameLang")]
    private static extern string GetPHealth();
    [DllImport("EngGameLang")]
    private static extern string GetCMode();
    [DllImport("EngGameLang")]
    private static extern string GetCObject();
    [DllImport("EngGameLang")]
    private static extern string GetPlay();
    [DllImport("EngGameLang")]
    private static extern string GetEdit();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
