using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Default
{
    public class Swipe : MonoBehaviour
    {
        [SerializeField] float deadZoneDistance = 0f;
        public GameObject uiPanelStart;
        public GameObject uiPanelLoose;
        private bool _tap;
        private bool _isDragging;
        private Vector2 startTouch, swipeDelta;

        public bool IsDragging
        {
            get { return _isDragging; }
        }
        public Vector2 SwipeDelta{
            get { return swipeDelta; }
        }
       
        private void Update() 
        { 
            if(!uiPanelStart.activeSelf && !uiPanelLoose.activeSelf){
                MoveDir = Direction.Default;
                _tap = false;
                _isDragging = false; //test

                // Vector2 prevSwipeDelta = swipeDelta;            

                if (Input.touches.Length > 0) {
                    if (Input.touches[0].phase == TouchPhase.Began) {
                        _isDragging = true;                    
                        _tap = true;                    
                        startTouch = Input.touches[0].position;
                        Debug.DrawLine(Vector3.zero, new Vector3(startTouch.x, startTouch.y, 0f), Color.red);
                    } else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                        _isDragging = false;                    
                        Reset();
                    } else {
                        _isDragging = true;
                        swipeDelta = Input.touches[0].position - startTouch;
                        // Debug.Log("swipeDelta: " + swipeDelta);
                    }
                } else if (Input.GetMouseButtonDown(0)) {
                    _isDragging = true;                
                    _tap = true;
                    startTouch = Input.mousePosition;
                } else if (Input.GetMouseButtonUp(0)) {
                    _isDragging = false;                
                    Reset();
                } else if (Input.GetMouseButton(0)) {
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
                }

                if (Mathf.Abs(swipeDelta.x) > deadZoneDistance) {
                    float x = swipeDelta.x;
                    // left or right
                    if (x < 0) {
                        MoveDir = Direction.Left;
                        if (!_isDragging) {
                            Reset();
                        }
                    } else {
                        MoveDir = Direction.Right;
                        if (!_isDragging) {
                            Reset();                        
                        }
                    } 
                }

                // if (prevSwipeDelta != swipeDelta) {
                //     _isDragging = true;
                // } else {
                //     _isDragging = false;
                // } 
            }            
        }        
        void Reset() {
            startTouch = swipeDelta = Vector2.zero;
            _isDragging = false;
            MoveDir = Direction.Default;
        }    

        public Direction MoveDir = Direction.Default;
    }

    public enum Direction
    {
        Default,
        Left,
        Right,
        Forward
    }
}
