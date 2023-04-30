using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Default
{
    
public class PickUpCubeScript : MonoBehaviour
{
    public CharacterObjMovement charMove;
    public int _pickedCubes;
    public Transform parent;
    private Vector3 currPos;


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Wall")
        {
            var go = Instantiate(this.gameObject, currPos, Quaternion.identity, parent);
            // currPos = charMove.transform.position;
            // currPos.y -= 5f;
            // go.transform.position = currPos;
            var stopPos = other.transform.position;
            stopPos.z -= 1f;
            go.transform.position = stopPos;
            Debug.Log("DestroyCube");
            _pickedCubes--;
            Destroy(gameObject);
            charMove.DecreeseY();
            other.GetComponent<Collider>().enabled = false;
        }        
    }
}
}
