using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Default
{
    
public class PickUpCubeScript : MonoBehaviour
{
    public CharacterObjMovement charMove;
    public int _pickedCubes;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Wall")
        {
            Debug.Log("DestroyCube");
            _pickedCubes--;
            Destroy(gameObject);
            charMove.DecreeseY();
            other.GetComponent<Collider>().enabled = false;
        }        
    }
}
}
