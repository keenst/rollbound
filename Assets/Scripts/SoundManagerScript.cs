using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip card1;
    static AudioSource aSource;
    
    void Start()
    {
        card1 = Resources.Load<AudioClip>("card1");

        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void PlaySound(string audioClip)
    {
        switch (audioClip)
        {
            case "card1" :
                aSource.PlayOneShot(card1);
                break;
        }
    }
}
