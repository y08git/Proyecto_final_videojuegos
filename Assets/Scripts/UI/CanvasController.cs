using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerUI;

    public GameObject dialogueBox;

    public void ActivePlayerUI(){
        playerUI.SetActive(true);
    }

    public void DeActivatePlayerUI(){
        playerUI.SetActive(false);
    }

    public void ActiveDialogueBox(){
        dialogueBox.SetActive(true);
    }

    public void DeActiveDialogueBox(){
        dialogueBox.SetActive(false);
    }
}
