using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    public SpriteRenderer SR;
    [SerializeField] private Sprite hatSprit;
    [SerializeField] private GameObject pickebleHat;
    [SerializeField] private GameObject hatButton;
    [SerializeField] public GameObject weareble;
    public GameObject hatManu;
    bool hasPickedUpHat;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            hatButton.SetActive(true);
            weareble.SetActive(true);
            pickebleHat.SetActive(false);
            hasPickedUpHat = true;
            SR.sprite = hatSprit;
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
