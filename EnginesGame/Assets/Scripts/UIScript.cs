using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [DllImport("EngGameLang")]
    private static extern void FillPlay(StringBuilder sb, int size);
    [DllImport("EngGameLang")]
    private static extern void FillEdit(StringBuilder sb, int size);
    [DllImport("EngGameLang")]
    private static extern void FillPHealth(StringBuilder sb, int size);
    [DllImport("EngGameLang")]
    private static extern void FillCMode(StringBuilder sb, int size);
    [DllImport("EngGameLang")]
    private static extern void FillCObject(StringBuilder sb, int size);

    string play;
    string edit;
    string pHealth;
    string cMode;
    string cObject;

    public Text upLeft;
    public Text botLeft;


    void Start()
    {
        StringBuilder sb = new StringBuilder(40);
        FillPlay(sb, sb.Capacity);
        play = sb.ToString();
        sb.Clear();

        FillEdit(sb, sb.Capacity);
        edit = sb.ToString();
        sb.Clear();

        FillPHealth(sb, sb.Capacity);
        pHealth = sb.ToString();
        sb.Clear();

        FillCMode(sb, sb.Capacity);
        cMode = sb.ToString();
        sb.Clear();

        FillCObject(sb, sb.Capacity);
        cObject = sb.ToString();
        sb.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariableScript.Instance.inEditor)
        {
            botLeft.text = cMode + ": " + edit;
            upLeft.text = cObject + ": " + GlobalVariableScript.Instance.selectedObject;
        }
        else
        {
            botLeft.text = cMode + ": " + play;
            upLeft.text = pHealth + ": " + GlobalVariableScript.Instance.playerHealth;
        }
    }
}
