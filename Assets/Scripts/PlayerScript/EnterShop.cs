using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterShop : MonoBehaviour
{
    bool isChangeing = false;
    public int sceneBuildIndex;
    [SerializeField] Animator ani;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ani.SetBool("changeScene", true);
            print("Swiching scene to " + sceneBuildIndex);
            isChangeing = true;
        }
    }
    private void changeScene()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        print("did done it");
    }
    void Start()
    {
    }
    void Update()
    {
        if(isChangeing == true)
        {
            isChangeing = false;
            print("will it done did it");
            Invoke("changeScene", 2);
        }
    }
}
