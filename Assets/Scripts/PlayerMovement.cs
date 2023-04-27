using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Default
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] bool isMoving = false;
        public float speed = 10f;
        Swipe swipe;

        


        void Start()
        {
            swipe = GetComponent<Swipe>();
        }

        void Update()
        {                     

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
