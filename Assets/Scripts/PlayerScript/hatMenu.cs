using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hatMenu : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite partyHatSprite;
    public Sprite dunceSpite;
    public Sprite wizardSprite;
    public Sprite gibusSprite;
    public Sprite anitaSprite;
    public GameObject takeOffHat;

    public void wearPartyHat()
    {
        spriteRenderer.sprite = partyHatSprite;
        takeOffHat.SetActive(true);
    }
    public void wearDunceHat()
    {
        spriteRenderer.sprite = dunceSpite;
        takeOffHat.SetActive(true);
    }
    public void waerWizardHat()
    {
        spriteRenderer.sprite = wizardSprite;
        takeOffHat.SetActive(true);
    }
    public void wearGibusHat()
    {
        spriteRenderer.sprite = gibusSprite;
        takeOffHat.SetActive(true);
    }
    public void wearAnitaHat()
    {
        spriteRenderer.sprite = anitaSprite;
        takeOffHat.SetActive(true);
        //takeOffHat.transform.position = new Vector2(0, 1);
    }
    public void noHat()
    {
        takeOffHat.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
