using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftwareRenderer : MonoBehaviour
{
    public int xSize;
    public int ySize;
    public Renderer quadRend;

    public Texture2D _texture2D;
    public Field field;
    private int changeX;
    private int changeY;
    private int r, g, b;
    [HideInInspector]
    public byte[] backBuffer;
    
    // Start is called before the first frame update
    void Start()
    {
        _texture2D = new Texture2D(xSize,ySize, TextureFormat.RGB24, false);
        _texture2D.filterMode = FilterMode.Point;
        quadRend.material.mainTexture = _texture2D;
        backBuffer = new byte[xSize * ySize* 3];
        //Set to red
        //backBuffer[6] = 255;
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateEverything();
        Render();
    }
    [ContextMenu("Update Everything")]
    void UpdateEverything()
    {
        //Update every pixel to this
        for (int i = 0; i < xSize * ySize * 3; i = i + 3)
        {
            //Testing if works - and it does
            backBuffer[i] = 0;
            backBuffer[i + 1] = 0;
            backBuffer[i + 2] = 0;
            //UpdateTex();
        }
        
    }

    [ContextMenu("Update Specific")]
    void SpecificUpdate()
    {
        //Set specific color to pixel
        if (((changeY * xSize) + changeX) *3 >= (xSize * ySize * 3) - 2) return;
        if (changeX < 0 || changeX > xSize -1 ) return;
        if (changeY < 0 || changeY >  ySize) return;
        
        
        backBuffer[((changeY * xSize) + changeX) * 3] = (byte)r;
        backBuffer[((changeY * xSize) + changeX) * 3 + 1] = (byte) g;
        backBuffer[((changeY * xSize) + changeX) * 3 + 2] = (byte) b;

        UpdateTex();
    }

    void UpdateTex()
    {
        //Update the texture
        _texture2D.LoadRawTextureData(backBuffer);
        _texture2D.Apply(false);
    }

    
    
    public void SetPixel(int posX, int posY, int red, int green, int blue)
    {

        changeX = posX;
        changeY = posY;
        r = red;
        g = green;
        b = blue;
        SpecificUpdate();
    }
    
    public float camDistance = 10;

    public void Set3DPixel(float x, float y, float z, int r,int g ,int b)
    {
        
        //Need to work in camera here
        float newPosX = x / (z * camDistance);
        float newPosY = y / (z * camDistance);

        float xCentre = xSize / 2;
        float yCentre = ySize / 2;
        SetPixel((int)(newPosX + xCentre), (int)(newPosY + yCentre),r,g,b);
        //Possibly need another function to update the 
    }

    void Wipe()
    {
        for (int i = 0; i < xSize * ySize * 3; i = i + 3)
        {
            backBuffer[((changeY * xSize) + changeX) * 3] = 0;
            backBuffer[((changeY * xSize) + changeX) * 3 + 1] = 0;
            backBuffer[((changeY * xSize) + changeX) * 3 + 2] = 0;
            UpdateTex();
        }
    }
    public void Render()
    {
        foreach (Star s in field.stars)
        {
            
            //renderer.SetPixel((int) s.myPosition.x, (int) s.myPosition.y, s.sR, s.sG, s.sB);
            //s.myPosition.x = s.myPosition.x + 1;
            
            Set3DPixel(s.myPosition.x,s.myPosition.y,s.myPosition.z, s.sR,s.sG,s.sB);
        }

        foreach (Mesh m in field.meshs)
        {
            foreach (Vertex v in m.Vertices)
            {
                Set3DPixel(m.position.x + v.position.x,m.position.y + v.position.y,m.position.z + v.position.z, v.sR,v.sG,v.sB);
            }
        }
        
    }
}
