using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Vector3Json
{
    public float x;
    public float y;
    public float z;

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }

    public Vector3Json(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3Json(Vector3 position)
    {
        this.x = position.x;
        this.y = position.y;
        this.z = position.z;
    }

    public Vector3Json()
    {
    }
}
