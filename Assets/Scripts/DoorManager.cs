using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [Header("Door")]
    [SerializeField] Animator doorAnimator = null;
    int doorType = 0;

    
     private string doorOpen = "DoorOpen";
     private string doorClose = "DoorClose";

     private bool isOpen = false;

    
    private int waitTimer = 1;
    private bool pauseInteraction = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AttributeManager>().attributes != doorType && isOpen == false)
        {
            SoundManager.PlaySound(SoundManager.SoundType.Alarm);

        }


            if ((other.gameObject.GetComponent<AttributeManager>().attributes & doorType) == doorType)
            {

                Debug.Log("TRIGGER ENTER");
            
           

              PlayAnimation();


            }

       
    }

   

    void OnTriggerExit(Collider other)
    {
        if (isOpen == true)
        {
            other.gameObject.GetComponent<AttributeManager>().attributes &= ~doorType;
        }
        
        

        Debug.Log(doorType + "EXIT");
    } 

   

    void Start()
    {

   
        if (this.gameObject.tag == "BLUE_DOOR") doorType = AttributeManager.BLUEKEY;
        if(this.gameObject.tag == "RED_DOOR") doorType = AttributeManager.REDKEY;


        if (this.gameObject.tag == "PURPLE_DOOR")
        { doorType = (AttributeManager.REDKEY | AttributeManager.BLUEKEY); }


        
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;

    }

    public void PlayAnimation()
    {
        
        if (!isOpen && !pauseInteraction)
        {
            doorAnimator.Play(doorOpen, 0, 0.0f);
            SoundManager.PlaySound(SoundManager.SoundType.Door);
            isOpen = true;
            StartCoroutine(PauseDoorInteraction());
        }

        else if (isOpen && !pauseInteraction)
        {
            doorAnimator.Play(doorClose, 0, 0.0f);
            isOpen = false;
            StartCoroutine(PauseDoorInteraction());
        }
    }
}
