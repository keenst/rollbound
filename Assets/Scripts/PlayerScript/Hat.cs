using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public GameObject pickebleHat;
    public GameObject dunceHat;
    public GameObject weareble;
    public GameObject hatManu;
    bool hasPickedUpHat;

    public GameObject partyHat;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            weareble.SetActive(true);
            pickebleHat.SetActive(false);
            hasPickedUpHat = true;
            partyHat.SetActive(true);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasPickedUpHat == true)
        {

        }
        if (Input.GetKeyDown(KeyCode.M))
        {

        }
    }
}
