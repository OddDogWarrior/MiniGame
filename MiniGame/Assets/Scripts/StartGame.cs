using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public LayerMask layer;
    public RaycastHit hit;

    public GameObject[] furniture;
    public GameObject[] boxArray;

    public
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.white);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 500, layer))
        {
            Debug.Log(hit.transform.gameObject.name);
        }

        GameOver();
    }

    public bool GameOver()
    {
        int numTrigger = 1;

        /*for (int i = 0; i < furniture.Length; i++)
        {
            if (furniture[i].GetComponent<Boxes>().trigger)
            {
                numTrigger++;
            }
        }*/
        for (int i = 0; i < boxArray.Length; i++)
        {
            if (boxArray[i].GetComponent<Boxes>().trigger)
            {
                numTrigger++;
                Debug.Log("numTrigger added");
            }
        }
        //issue is that it only runs the numTrigger++ only one time and it keeps increasing
        if (numTrigger >= 2)
        {
            return true;
            Debug.Log("Game Over");
        }
        else
        {
            return false;
        }
    }

    /*public static void Main(string[] args)
    {
        GetComponent<Boxes>().hidingPlaces();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Box_1")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            hidingPlaces();
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Box_2")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            hidingPlaces();
        }
    }*/
}
