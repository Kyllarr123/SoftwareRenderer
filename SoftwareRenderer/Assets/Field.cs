using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int numberOfStars;
    public int numberOfMeshs;
    public Vector3 position;
    public SoftwareRenderer renderer;
    public Star star;
    public float speed;
    public float rotationSpeed;
    public List<Star> stars = new List<Star>();

    public Mesh mesh;
    public List<Mesh> meshs = new List<Mesh>();
    // Start is called before the first frame update


    private void Start()
    {
        //yield return new WaitForSeconds(1);
        for (var i = 0; i < numberOfStars; i++)
        {
            star = new Star(position, 255, 255, 255);
            star.myPosition.x = Random.Range(-renderer.xSize * 0.1f, renderer.xSize * 0.1f);
            star.myPosition.y = Random.Range(-renderer.ySize * 0.1f, renderer.ySize * 0.1f);
            stars.Add(star);

            Debug.Log("made Star" + stars.Count);
            
        }

        for (int i = 0; i < numberOfMeshs; i++)
        {
            mesh = new Mesh(position);
            mesh.position.x = Random.Range(-renderer.xSize * 0.1f , renderer.xSize * 0.1f );
            mesh.position.y = Random.Range(-renderer.ySize * 0.1f , renderer.ySize * 0.1f );
            meshs.Add(mesh);
        }
        
    }

    public IEnumerator SpawnMoreStars()
    {
        Star newStar = new Star(position, 255, 255, 255);
        newStar.myPosition.x = Random.Range(-renderer.xSize * 0.2f, renderer.xSize * 0.2f);
        newStar.myPosition.y = Random.Range(-renderer.ySize * 0.2f, renderer.ySize * 0.2f);
        stars.Add(newStar);
        yield return new WaitForSeconds(0.001f);
    }

    public void Render()
    {
        foreach (Star s in stars)
        {
            
            //renderer.SetPixel((int) s.myPosition.x, (int) s.myPosition.y, s.sR, s.sG, s.sB);
            //s.myPosition.x = s.myPosition.x + 1;
            
            //renderer.Set3DPixel(s.myPosition.x,s.myPosition.y,s.myPosition.z,);
        }
        
        
    }

    public float maxCount;

    public void UpdatePosition()
    {
        
        foreach (Star s in stars)
        {
            s.myPosition.z = s.myPosition.z + (speed * Time.deltaTime);
        }
        foreach (Mesh m in meshs)
        {
            
            m.position.z = m.position.z + (speed * Time.deltaTime);
            m.Rotate(new Vector3(m.rotation.x,m.rotation.y,m.rotation.z + (rotationSpeed * Time.deltaTime)));
        }
        

        if (stars.Count > maxCount)
        {
            stars.RemoveAt(0);
        }
    }
    
    

    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(SpawnMoreStars());
        UpdatePosition();
        //Render();
        
        //Getting an idea of what needs to happen
    }
}