using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatMenu : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite partyHatSprite;
    public Sprite dunceSpite;

    public void wearPartyHat()
    {
        spriteRenderer.sprite = partyHatSprite;
    }
    public void wearDunceHat()
    {
        spriteRenderer.sprite = dunceSpite;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
