using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollCheck : MonoBehaviour
{
    public GameObject loosePanel;

    private void OnTriggerEnter(Collider other) 
    {     
        if(other.gameObject.tag == "Wall" || other.gameObject.tag == "Ground")
        {
            // Debug.Log("Loose");
            loosePanel.gameObject.SetActive(true);
        }
    }     
}
