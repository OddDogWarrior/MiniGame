using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Boxes : MonoBehaviour
{
    private Collider box;
    private GameObject halfBox;

    public bool trigger;
    public LayerMask layer;
    public RaycastHit hit;
    public GameObject[] furniture;
    private GameObject furnitureSelect;


    int index;
    // Start is called before the first frame update
    void Start()
    {

        hidingPlaces();

        box = GetComponent<Collider>();
        box.isTrigger = false;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.white);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 500, layer))
        {
            box.isTrigger = true;
            //Destroy(box.gameObject);
            Debug.Log(hit.transform.gameObject.name);

            trigger = true;
        }

    }

    public static void hidingPlaces()
    {
        index = Random.Range(0, furniture.Length);
        furnitureSelect = furniture[index];
        Debug.Log(furnitureSelect.transform.name);

        transform.position = new Vector3(furnitureSelect.transform.position.x, furnitureSelect.transform.position.y, furnitureSelect.transform.position.z);
    }



}

