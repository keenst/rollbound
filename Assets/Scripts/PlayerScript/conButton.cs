using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class conButton : MonoBehaviour
{
    public int sceneBuildIndex;
    public void Click()
    {
        print("Swiching scene to " + sceneBuildIndex);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
