using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectCommand : ICommand
{
    GameObject placing;
    GameObject active;
    Vector3 pos;
    Quaternion rot;

    public PlaceObjectCommand(GameObject placing, Vector3 pos, Quaternion rot)
    {
        this.placing = placing;
        this.pos = pos;
        this.rot = rot;
    }
    public void Execute()
    {
        active =  GameObject.Instantiate(placing, pos, rot);
    }

    public void Undo()
    {
        GameObject.Destroy(active);
    }
}
