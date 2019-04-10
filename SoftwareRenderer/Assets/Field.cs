using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int numberOfStars;
    public Vector3 position;
    public SoftwareRenderer renderer;
    public Star star;
    public float speed;
    public List<Star> stars = new List<Star>();
    // Start is called before the first frame update


    private void Start()
    {
        //yield return new WaitForSeconds(1);
        for (var i = 0; i < numberOfStars; i++)
        {
            star = new Star(position, 255, 255, 255);
            star.myPosition.x = Random.Range(-renderer.xSize * 0.2f, renderer.xSize * 0.2f);
            star.myPosition.y = Random.Range(-renderer.ySize * 0.2f, renderer.ySize * 0.2f);
            stars.Add(star);

            Debug.Log("made Star" + stars.Count);
            
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
            
            renderer.Set3DPixel(s.myPosition.x,s.myPosition.y,s.myPosition.z);
        }
    }

    public float maxCount = 125;

    public void UpdatePosition()
    {
        
        foreach (Star s in stars)
        {
            s.myPosition.z = s.myPosition.z + (speed * Time.deltaTime);
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
        Render();
        
        //Getting an idea of what needs to happen
    }
}