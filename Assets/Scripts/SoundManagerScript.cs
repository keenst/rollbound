using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    #region sound effects
    public static AudioClip card1;
    public static AudioClip card2;
    public static AudioClip diceStart;
    public static AudioClip diceEnd;
    public static AudioClip Armorwear;
    public static AudioClip Bite;
    public static AudioClip bloodymummy1;
    public static AudioClip bloodymummy2;
    public static AudioClip Crossbow;
    public static AudioClip finalboss1;
    public static AudioClip finalboss2;
    public static AudioClip finalboss3;
    public static AudioClip finalbossdie;
    public static AudioClip freeze;
    public static AudioClip herbalTonic;
    public static AudioClip legendArmorWear;
    public static AudioClip lizardman1;
    public static AudioClip lizardman2;
    public static AudioClip merchant1;
    public static AudioClip merchant2;
    public static AudioClip merchant3;
    public static AudioClip Parry;
    public static AudioClip physcboss1;
    public static AudioClip physcboss2;
    public static AudioClip physicalbossdie;
    public static AudioClip Poison;
    public static AudioClip Punch;
    public static AudioClip purchase;
    public static AudioClip Rock;
    public static AudioClip Shield;
    public static AudioClip sickle;
    public static AudioClip smiteAxe;
    public static AudioClip smiteMagic;
    public static AudioClip spita1;
    public static AudioClip spita2;
    public static AudioClip Stab;
    public static AudioClip zom1;
    public static AudioClip zom2;
    public static AudioClip zom3;
    public static AudioClip zom1a;
    public static AudioClip zom2a;
    public static AudioClip zom3a;
    #endregion
    #region OST
    public static AudioClip BossThemeHorde;
    public static AudioClip BossThemePhysical;
    public static AudioClip CaveAmbience;
    public static AudioClip CaveCombatAmbience;
    public static AudioClip DungeonDeepAmbience;
    public static AudioClip DungeonDeepCombatAmbience;
    public static AudioClip DungeonOvergrowthAmbience;
    public static AudioClip DungeonOvergrowthCombatAmbience;
    public static AudioClip FinalBoss;
    public static AudioClip ForestAmbience;
    public static AudioClip ForestCombatAmbience;
    public static AudioClip RuinedLibraryAmbience;
    public static AudioClip RuinedLibraryCombatAmbience;
    #endregion

    static AudioSource aSource;

    void Start()
    {
        card1 = Resources.Load<AudioClip>("card1");
        card2 = Resources.Load<AudioClip>("card2");
        diceStart = Resources.Load<AudioClip>("diceStart");
        diceEnd = Resources.Load<AudioClip>("diceEnd");
        Armorwear = Resources.Load<AudioClip>("Armorwear");
        Bite = Resources.Load<AudioClip>("Bite");
        bloodymummy1 = Resources.Load<AudioClip>("bloodymummy1");
        bloodymummy2 = Resources.Load<AudioClip>("bloodymummy2");
        Crossbow = Resources.Load<AudioClip>("Crossbow");
        finalboss1 = Resources.Load<AudioClip>("finalboss1");
        finalboss2 = Resources.Load<AudioClip>("finalboss2");
        finalboss3 = Resources.Load<AudioClip>("finalboss3");
        finalbossdie = Resources.Load<AudioClip>("finalbossdie");
        freeze = Resources.Load<AudioClip>("freeze");
        herbalTonic = Resources.Load<AudioClip>("herbalTonic");
        legendArmorWear = Resources.Load<AudioClip>("legendArmorWear");
        lizardman1 = Resources.Load<AudioClip>("lizardman1");
        lizardman2 = Resources.Load<AudioClip>("lizardman2");
        merchant1 = Resources.Load<AudioClip>("merchant1");
        merchant2 = Resources.Load<AudioClip>("merchant2");
        merchant3 = Resources.Load<AudioClip>("merchant3");
        Parry = Resources.Load<AudioClip>("Parry");
        physcboss1 = Resources.Load<AudioClip>("physcboss1");
        physcboss2 = Resources.Load<AudioClip>("physcboss2");
        physicalbossdie = Resources.Load<AudioClip>("physicalbossdie");
        Poison = Resources.Load<AudioClip>("Poison");
        Punch = Resources.Load<AudioClip>("Punch");
        purchase = Resources.Load<AudioClip>("purchase");
        Rock = Resources.Load<AudioClip>("Rock");
        Shield = Resources.Load<AudioClip>("Shield");
        sickle = Resources.Load<AudioClip>("sickle");
        smiteAxe = Resources.Load<AudioClip>("smiteAxe");
        smiteMagic = Resources.Load<AudioClip>("smiteMagic");
        spita1 = Resources.Load<AudioClip>("spita1");
        spita2 = Resources.Load<AudioClip>("spita2");
        Stab = Resources.Load<AudioClip>("Stab");
        zom1 = Resources.Load<AudioClip>("zom1");
        zom2 = Resources.Load<AudioClip>("zom2");
        zom3 = Resources.Load<AudioClip>("zom3");
        zom1a = Resources.Load<AudioClip>("zom1a");
        zom2a = Resources.Load<AudioClip>("zom2a");
        zom3a = Resources.Load<AudioClip>("zom3a");
        BossThemeHorde = Resources.Load<AudioClip>("BossThemeHorde");
        BossThemePhysical = Resources.Load<AudioClip>("BossThemePhysical");
        CaveAmbience = Resources.Load<AudioClip>("Cave Ambience");
        CaveCombatAmbience = Resources.Load<AudioClip>("Cave Combat Ambience");
        DungeonDeepAmbience = Resources.Load<AudioClip>("DungeonDeep Ambience");
        DungeonDeepCombatAmbience = Resources.Load<AudioClip>("DungeonDeep Combat Ambience");
        DungeonOvergrowthAmbience = Resources.Load<AudioClip>("DungeonOvergrowth Ambience");
        DungeonOvergrowthCombatAmbience = Resources.Load<AudioClip>("DungeonOvergrowth Combat Ambience");
        FinalBoss = Resources.Load<AudioClip>("Final Boss");
        ForestAmbience = Resources.Load<AudioClip>("Forest Ambience");
        ForestCombatAmbience = Resources.Load<AudioClip>("Forest Combat Ambience");
        RuinedLibraryAmbience = Resources.Load<AudioClip>("Ruined Library Ambience");
        RuinedLibraryCombatAmbience = Resources.Load<AudioClip>("Ruined Library Combat Ambience");

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
            case "card1":
                aSource.PlayOneShot(card1);
                break;
            
            case "card2":
                aSource.PlayOneShot(card2);
                break;
            
            case "diceStart":
                aSource.PlayOneShot(diceStart);
                break;
            
            case "diceEnd":
                aSource.PlayOneShot(diceEnd);
                break;
            
            case "Armorwear":
                aSource.PlayOneShot(Armorwear);
                break;
            
            case "Bite":
                aSource.PlayOneShot(Bite);
                break;
            
            case "bloodymummy1":
                aSource.PlayOneShot(bloodymummy1);
                break;
            
            case "bloodymummy2":
                aSource.PlayOneShot(bloodymummy2);
                break;
            
            case "Crossbow":
                aSource.PlayOneShot(Crossbow);
                break;
            
            case "finalboss1":
                aSource.PlayOneShot(finalboss1);
                break;
            
            case "finalboss2":
                aSource.PlayOneShot(finalboss2);
                break;
            
            case "finalboss3":
                aSource.PlayOneShot(finalboss3);
                break;
            
            case "finalbossdie":
                aSource.PlayOneShot(finalbossdie);
                break;
            
            case "freeze":
                aSource.PlayOneShot(freeze);
                break;
            
            case "herbalTonic":
                aSource.PlayOneShot(herbalTonic);
                break;
            
            case "legendArmorWear":
                aSource.PlayOneShot(legendArmorWear);
                break;
            
            case "lizardman1":
                aSource.PlayOneShot(lizardman1);
                break;
            
            case "lizardman2":
                aSource.PlayOneShot(lizardman2);
                break;
            
            case "merchant1":
                aSource.PlayOneShot(merchant1);
                break;
            
            case "merchant2":
                aSource.PlayOneShot(merchant2);
                break;
            
            case "merchant3":
                aSource.PlayOneShot(merchant3);
                break;
            
            case "Parry":
                aSource.PlayOneShot(Parry);
                break;
            
            case "physcboss1":
                aSource.PlayOneShot(physcboss1);
                break;
            
            case "physcboss2":
                aSource.PlayOneShot(physcboss2);
                break;
            
            case "physicalbossdie":
                aSource.PlayOneShot(physicalbossdie);
                break;
            
            case "Poison":
                aSource.PlayOneShot(Poison);
                break;
            
            case "Punch":
                aSource.PlayOneShot(Punch);
                break;
            
            case "purchase":
                aSource.PlayOneShot(purchase);
                break;
            
            case "Rock":
                aSource.PlayOneShot(Rock);
                break;
            
            case "Shield":
                aSource.PlayOneShot(Shield);
                break;
            
            case "sickle":
                aSource.PlayOneShot(sickle);
                break;
            
            case "smiteAxe":
                aSource.PlayOneShot(smiteAxe);
                break;
            
            case "smiteMagic":
                aSource.PlayOneShot(smiteMagic);
                break;
            
            case "spita1":
                aSource.PlayOneShot(spita1);
                break;
            
            case "spita2":
                aSource.PlayOneShot(spita2);
                break;
            
            case "Stab":
                aSource.PlayOneShot(Stab);
                break;
            
            case "zom1":
                aSource.PlayOneShot(zom1);
                break;
            
            case "zom2":
                aSource.PlayOneShot(zom2);
                break;
            
            case "zom3":
                aSource.PlayOneShot(zom3);
                break;
            
            case "zom1a":
                aSource.PlayOneShot(zom1a);
                break;
            
            case "zom2a":
                aSource.PlayOneShot(zom2a);
                break;
            case "zom3a":
                aSource.PlayOneShot(zom3a);
                break;
            
            case "BossThemeHorde":
                aSource.PlayOneShot(BossThemeHorde);
                break;
            
            case "BossThemePhysical":
                aSource.PlayOneShot(BossThemePhysical);
                break;
           
            case "Cave Ambience":
                aSource.PlayOneShot(CaveAmbience);
                break;
            
            case "Cave Combat Ambience":
                aSource.PlayOneShot(CaveCombatAmbience);
                break;
            
            case "DungeonDeep Ambience":
                aSource.PlayOneShot(DungeonDeepAmbience);
                break;
           
            case "DungeonDeep Combat Ambience":
                aSource.PlayOneShot(DungeonDeepCombatAmbience);
                break;
            
            case "DungeonOvergrowth Ambience":
                aSource.PlayOneShot(DungeonOvergrowthAmbience);
                break;
            
            case "DungeonOvergrowth Combat Ambience":
                aSource.PlayOneShot(DungeonOvergrowthCombatAmbience);
                break;
           
            case "Final Boss":
                aSource.PlayOneShot(FinalBoss);
                break;
            
            case "Forest Ambience":
                aSource.PlayOneShot(ForestAmbience);
                break;
            
            case "Forest Combat Ambience":
                aSource.PlayOneShot(ForestCombatAmbience);
                break;
            
            case "Ruined Library Ambience":
                aSource.PlayOneShot(RuinedLibraryAmbience);
                break;
            case "Ruined Library Combat Ambience":
                aSource.PlayOneShot(RuinedLibraryCombatAmbience);
                break;
        }
    }
}
