using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Combat");
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
