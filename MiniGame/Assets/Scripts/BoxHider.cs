using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BoxHider : MonoBehaviour
{
    public Collider box1Col;
    public Collider box2Col;
    public LayerMask layer;
    public RaycastHit hit;
    public GameObject[] furniture;
    public GameObject[] boxes;
    public GameObject furnitureSelect;
    public StartGame sg;
   //public UnityEvent test;


    public int index;


    void Start()
    {

        hidingPlaces();

        //boxCol = GetComponent<Collider>();
        //boxCol.isTrigger = false;

        //here's the issue, the colliders won't work, why? because they don't have rigidbodies, when i give them rigidbodies they don't merge with the furniture anymore so they just fall on the ground
        //so I try to make the objects ignore the furniture layer so they can pass but it's not working

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.white);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 500, layer))
        {
            if (hit.transform.tag == "Box 1")
            {
                hit.transform.GetComponent<BoxFound>().found = true;
                Debug.Log(hit.transform.gameObject.name);
                sg.numFound++;
                Debug.Log(sg.numFound + " num found");
            }
        }

     
    }

    public void hidingPlaces()
    {
        foreach (GameObject box in boxes)
        {

        index = Random.Range(0, furniture.Length);
        int prevIndex = index;
        while (prevIndex == index)
        {
            index = Random.Range(0, furniture.Length);
        }
        furnitureSelect = furniture[index];
        Debug.Log(furnitureSelect.transform.name);

        box.transform.position = furnitureSelect.transform.position;
        box.transform.localScale = furnitureSelect.transform.localScale;
      }
    }

    void OnCollisionEnter(Collision collision)
    {
       
        /*if (box1Col.gameObject.name == "Box_2" || box2Col.gameObject.name == "Box_1")
        {
            Debug.Log("ARE YOU WORKING???");
            //If the GameObject's name matches the one you suggest, output this message in the console
            hidingPlaces();
            Debug.Log(furnitureSelect.transform.name);
        }*/
        //I added test, see if anything can be done with it, it's called a unity event
        //original vv
        /*if (collision.gameObject.name == "Box_1" || collision.gameObject.name == "Box_2")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            hidingPlaces();
            Debug.Log(furnitureSelect.transform.name + "ARE YOU WORKING???");
        }*/

        if (collision.gameObject.name == "Box_2" || collision.gameObject.name == "Box_1")
        {
            Debug.Log("ARE YOU WORKING???");
            //If the GameObject's name matches the one you suggest, output this message in the console
            hidingPlaces();
        }

    }

}