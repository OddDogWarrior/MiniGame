using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxHider : MonoBehaviour
{
    public Collider boxCol;
    public LayerMask layer;
    public RaycastHit hit;
    public GameObject[] furniture;
    public GameObject[] boxes;
    public GameObject furnitureSelect;
    public StartGame sg;


    public int index;


    void Start()
    {

        hidingPlaces();

        //boxCol = GetComponent<Collider>();
        //boxCol.isTrigger = false;

    }

    // Update is called once per frame
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
      }
    }



}

