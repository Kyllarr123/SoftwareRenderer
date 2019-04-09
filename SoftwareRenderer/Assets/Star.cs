using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star
{

    public Vector3 myPosition;

    public int sR = 255, sG = 255, sB = 255;
    // Start is called before the first frame update
    public Star(Vector3 position, int r, int g, int b)
    {
        myPosition.x = position.x;
        myPosition.y = position.y;
        myPosition.z = 1;
    }

}
