using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    
    [SerializeField] private GameObject conMenu;
    public int sceneBuildIndex;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            conMenu.SetActive(true);
            /*print("Swiching scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);*/
        }
    }
    /*private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                conMenu.SetActive(true);
                print("Swiching scene to " + sceneBuildIndex);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            }

        }
    }*/
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            conMenu.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
