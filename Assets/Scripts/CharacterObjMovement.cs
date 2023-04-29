using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Default {
public class CharacterObjMovement : MonoBehaviour
{
    public Swipe swipe;

    public GameObject alfaCube;
    public GameObject counter;

    public float sideSpeed = 0.1f;
    float maxX = 2f;
    float minX = -2f;

    [SerializeField] private GameObject cube;
    [SerializeField] int currAmountOfCubes = 0;
    Vector3 _grow; 
    PickUpCubeScript _pickScript;
    public Transform cubeParent;
    public float growY = 1f;
    public int _pickedCubes;
    public float y = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
        swipe = GetComponent<Swipe>();
        _pickScript = alfaCube.GetComponent<PickUpCubeScript>();
        _grow.y = growY;
    }

    // Update is called once per frame
    void Update()
    {        
        if (swipe.MoveDir == Direction.Left || swipe.MoveDir == Direction.Right)
        {
            if (swipe.IsDragging)
            {
                Vector3 direction = (swipe.MoveDir == Direction.Left) ? Vector3.left : Vector3.right;
                Vector3 newPos = transform.position + direction * (swipe.SwipeDelta.magnitude / 100) * sideSpeed * Time.deltaTime;
                newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
                transform.position = newPos;               
            }
            if (!swipe.IsDragging)
            {
                swipe.MoveDir = Direction.Default;
            }
        }

        if (_pickedCubes > currAmountOfCubes)
        {
            transform.position += _grow;

            var go = Instantiate(cube, transform.position - new Vector3(0, y, 0), Quaternion.identity, cubeParent.transform);
            y++;
            go.tag = "Untagged";
            currAmountOfCubes = _pickedCubes;
            counter.gameObject.SetActive(true);
            Invoke("DisableCounter", .7f);
        } 
    }  

    void DisableCounter()
    {
        counter.gameObject.SetActive(false);
    }

    public void DecreeseY()
    {
        transform.position -= _grow;  
        y--;      
        _pickedCubes--;
        currAmountOfCubes = _pickedCubes;
    }   

    private void OnTriggerEnter(Collider other) 
    {  
        if (other.gameObject.CompareTag("PickUpCube")){
            _pickedCubes++;
            Destroy(other.gameObject);
        }
    }     
    }
}



