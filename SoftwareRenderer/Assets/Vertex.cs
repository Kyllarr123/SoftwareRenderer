using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex
{

    public Vector3 position;

    public int sR = 255, sG = 0, sB = 0;
    public Vertex(Vector3 pos, int r, int g, int b)
    {
        position.x = pos.x;
        position.y = pos.y;
        position.z = pos.z;
    }
}
