using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public LayerMask layer;
    public RaycastHit hit;
    public int numFound;
    //public GameObject[] furniture;
    public GameObject[] boxArray;
    public GameObject halfPopUp;
    public GameObject gameOverPopUp;
    
    private float distance = 2.0f;
    private float timeWaited = 2.5f;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(TimeWait());
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.white);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 10, layer))
        {
            Debug.Log(hit.transform.gameObject.name);
            //source.Play();

            if(hit.collider != null)
                    {
                        var audioTrigger = hit.collider.gameObject.GetComponent<AudioTrigger>();
                        if (audioTrigger != null)
                        {
                            audioTrigger.OnRayHit();
                        }
                    }
        }


        //add if gameover is true load game over screen see manager overload
        /*if(hit.collider.gameObject.layer = true)
        {
            source.Play();
        }*/
        GameOver();
    }

    public bool GameOver()
    {
        if (numFound == 1)
        {
            halfPopUp.gameObject.SetActive(true);
            halfPopUp.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
            halfPopUp.transform.rotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);
            if (timeWaited > 0)
            {
                timeWaited -= Time.deltaTime;
            }
            else
            {
                halfPopUp.gameObject.SetActive(false);
            }
        }
        if (numFound == 2)
        {

            gameOverPopUp.gameObject.SetActive(true);
            gameOverPopUp.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
            gameOverPopUp.transform.rotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);

            Debug.Log("Game Over");
            return true;

        }
        else
        {
            return false;
        }
    }

    /*IEnumerator TimeWait()
    {
        while (true)
        {
            
            halfPopUp.gameObject.SetActive(true);
            halfPopUp.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distance;
            halfPopUp.transform.rotation = new Quaternion(0.0f, Camera.main.transform.rotation.y, 0.0f, Camera.main.transform.rotation.w);
            yield return new WaitForSeconds(timeWaited);
            halfPopUp.gameObject.SetActive(false);
        }
    }*/

    
}
