using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public int numberOfStars;
    public Vector3 position;
    public SoftwareRenderer renderer;
    public Star star;

    public List<Star> stars = new List<Star>();
    // Start is called before the first frame update


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        for (var i = 0; i < numberOfStars; i++)
        {
            star = new Star(position, 255, 255, 255);
            star.myPosition.x = Random.Range(renderer.xSize /2 - 10, renderer.xSize/2 + 10);
            star.myPosition.y = Random.Range(renderer.ySize/2 - 10, renderer.ySize/2 + 10);
            stars.Add(star);

            Debug.Log("made Star" + stars.Count);
        }
    }

    public void Render()
    {
        foreach (Star s in stars)
        {
            
            renderer.SetPixel((int) s.myPosition.x, (int) s.myPosition.y, s.sR, s.sG, s.sB);
            //s.myPosition.x = s.myPosition.x + 1;
        }
    }

    public void UpdatePosition()
    {
        foreach (Star s in stars)
        {
            
            
            
        }
    }
    
    

    // Update is called once per frame
    private void Update()
    {
        //UpdatePosition();
        Render();
        
        //Getting an idea of what needs to happen
    }
}