using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform pointPrefab;
    void Awake()
    {
        for (int i=0; i<10; i++) { //iterate 10 times, i goes up a point to be (1,0,0)*2 in the next loop, etc.
            
            Transform point = Instantiate(pointPrefab); //creates a prefab instance
            point.localPosition = Vector3.right * ((i+0.5f)/5f - 1f); //moves it (1,0,0)*i, and fills a (-1,1 range)
            point.localScale = Vector3.one / 5f; //shrinks the prefab to a fifth. To bring them into a straight line, divide the position by the same amount as the scale
             
            
        }
        
         //moves the instance by X,Y,Z=(1,0,0)

        
    }

    
}
