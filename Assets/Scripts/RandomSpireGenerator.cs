using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpireGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float levelLength;
    public GameObject tower;
    
    Vector3 GetTerrainPosition() {
        float z = Random.Range(-11f,11f);
        float x = Random.Range(0f, levelLength);
        return new Vector3(x,0,z);
    }
    
    public void SpawnObjects() {
        Vector3 position = GetTerrainPosition();
        GameObject.Instantiate(tower,position, Quaternion.identity);
    }
}
