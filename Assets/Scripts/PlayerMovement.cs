using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Default
{
    public class PlayerMovement : MonoBehaviour
    {
        bool isMoving = false;
        public float speed = 10f;
        Swipe swipe;
        public GameObject uiPanelStart;
        public GameObject uiPanelLoose;

        void Start()
        {
            swipe = GetComponent<Swipe>();
        }

        void Update()
        {                     
            if(!uiPanelStart.activeSelf && !uiPanelLoose.activeSelf){
                if(Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    if(touch.phase == TouchPhase.Began)
                    {
                        isMoving = true;
                    }
                    else if(touch.phase == TouchPhase.Ended)
                    {
                        isMoving = false;
                    }
                }  
                    
                if(isMoving){
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
            }                   
        }            
    }
}
