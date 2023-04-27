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
    
    Vector2 lastSwipeDelta;
    Vector3 newCube;

    [SerializeField] private GameObject cube;
    [SerializeField] Vector3 _grow; 
    [SerializeField] int currAmountOfCubes = 0;
    PickUpCubeScript _pickScript;
    public Transform cubeParent;
    public float growY = 1f;
    public int _pickedCubes;
    public float y = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
        swipe = GetComponent<Swipe>();
        lastSwipeDelta = Vector2.zero;
        _pickScript = alfaCube.GetComponent<PickUpCubeScript>();
        newCube = transform.position;
        _grow.y = growY;
    }

    // Update is called once per frame
    void Update()
    {
        // currentPos = transform.position;
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

            
            // _groundY++;
            var go = Instantiate(cube, transform.position - new Vector3(0, y, 0), Quaternion.identity, cubeParent.transform);
            y++;
            go.tag = "Untagged";
            currAmountOfCubes = _pickedCubes;
            StartCoroutine(CountRoutine());
        } 
    }  

    IEnumerator CountRoutine()
    {
        counter.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        counter.gameObject.SetActive(false);
    }

    public void DecreeseY()
    {
        Debug.Log("Decreese Y");        
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



