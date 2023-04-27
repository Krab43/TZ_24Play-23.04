using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoadGenerator : MonoBehaviour
{
    [SerializeField] int tileCount = 15;
    [SerializeField] GameObject tilePrefab;      
    Vector3 newGeneratedPos;
    public Transform roadHolder;
        
    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < tileCount; i++)
        {
            CreateTileObj();
        }        
    }
    
    public void CreateTileObj()
    {
        GameObject go = Instantiate(tilePrefab, newGeneratedPos, Quaternion.identity, roadHolder);
        newGeneratedPos = go.transform.GetChild(1).transform.position;

    }   
}
