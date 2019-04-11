using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh
{

    public Vertex[] Vertices;
    public Vertex[] OriginalVertices;
    public Vector3 position;
    public Vector3 rotation;
    public int r;
    public int g;
    public int b;
    public Vector3 scale;
    public Mesh(Vector3 pos)
    {
        
        position = pos;
        position.z = 1;


        r = 255;
        g = 0;
        b = 0;
        OriginalVertices = new Vertex[8];

        OriginalVertices[0] = new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), r, g, b);
        OriginalVertices[1] = new Vertex(new Vector3(-0.5f, -0.5f, 0.5f), r, g, b);
        OriginalVertices[2] = new Vertex(new Vector3(-0.5f, 0.5f, -0.5f), r, g, b);
        OriginalVertices[3] = new Vertex(new Vector3(-0.5f, 0.5f, 0.5f), r, g, b);
        OriginalVertices[4] = new Vertex(new Vector3(0.5f, 0.5f, 0.5f), r, g, b);
        OriginalVertices[5] = new Vertex(new Vector3(0.5f, 0.5f, -0.5f), r, g, b);
        OriginalVertices[6] = new Vertex(new Vector3(0.5f, -0.5f, 0.5f), r, g, b);
        OriginalVertices[7] = new Vertex(new Vector3(0.5f, -0.5f, -0.5f), r, g, b);

        Vertices = OriginalVertices;
    }

    public void Rotate(Vector3 rot)
    {
        rotation = rot;
        
        for (int i = 0; i < Vertices.Length; i++)
        {
            float newX = (Mathf.Cos(rotation.z) * OriginalVertices[i].position.x) +
                         (-Mathf.Sin(rotation.z) * OriginalVertices[i].position.y);
            float newY = (Mathf.Sin(rotation.z) * OriginalVertices[i].position.x) +
                         (Mathf.Cos(rotation.z) * OriginalVertices[i].position.y);

            OriginalVertices[i].position.x = newX;
            OriginalVertices[i].position.y = newY;
        }
    }


}
