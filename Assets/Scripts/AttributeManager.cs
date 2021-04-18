using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    static public int BLUEKEY = 4;
    static public int REDKEY = 2;
    static public int GREENKEY = 1;

   
    public int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "BLUE_KEY")
        {
            attributes |= BLUEKEY;
            SoundManager.PlaySound(SoundManager.SoundType.KeyPick);
            Destroy(other.gameObject,.1f);
        }
        else if (other.gameObject.tag == "RED_KEY")
        {
            attributes |= REDKEY;
            SoundManager.PlaySound(SoundManager.SoundType.KeyPick);
            Destroy(other.gameObject, .1f);
        }
        else if (other.gameObject.tag == "GREEN_KEY")
        {
            attributes |= GREENKEY;
            SoundManager.PlaySound(SoundManager.SoundType.KeyPick);
            Destroy(other.gameObject, .1f);
        }
       /* else if (other.gameObject.tag == "GOLD_KEY")
        {
            attributes |= (BLUEKEY | REDKEY | GREENKEY);
            SoundManager.PlaySound(SoundManager.SoundType.KeyPick);
            Destroy(other.gameObject, .2f);
        } */
    }

    
}
