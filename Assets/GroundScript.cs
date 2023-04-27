using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    RoadGenerator _rg;
    [SerializeField] GameObject wallPrefab;
    [SerializeField] GameObject pickPrefab;
    public Transform roadHolder;
    

    private void Start()
    {
        _rg = GameObject.FindObjectOfType<RoadGenerator>();
        SpawnBlocks();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject, 3f);
            _rg.CreateTileObj();
        }
        
    }

    public void SpawnBlocks()
    {       
        Transform wallSpawner = transform.GetChild(2).transform;
        Vector3 spawnPos = wallSpawner.transform.position;

        int randomWallY;

        for (int i = 0; i < 5; i++){
            randomWallY = Random.Range(1, 4);
            for (int j = 0; j < randomWallY; j++){
                Instantiate(wallPrefab, spawnPos, Quaternion.identity, _rg.roadHolder);                
                spawnPos.y += 1f;                
            }
            spawnPos.x += 1f;
            spawnPos.y -= randomWallY;
        }

        SpawnPickableObj();
    }

    void SpawnPickableObj()
    {
        Transform wallSpawner = transform.GetChild(3).transform;
        Vector3 spawnPos = wallSpawner.transform.position;


        for (int i = 0; i < 3; i++)
        {   
            int randomPickableObjX = Random.Range(0, 4);
            for (int j = 0; j < 3; j++)
            {         
                int randomPickableObjY = Random.Range(0, 4);       
                GameObject go = pickPrefab;
                if (randomPickableObjX <= 2 && randomPickableObjY <= 2){
                    Instantiate(go, spawnPos, Quaternion.identity, _rg.roadHolder);
                }
                spawnPos.z -= 2f;
            }         
            spawnPos.x += 2f;
        }
    }

}
