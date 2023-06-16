using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvent : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _canvas;

    private CanvasController _canvasController;

    private DialogueBox _dialoguebox;

    [SerializeField]
    private string layer_name;

    private bool writing = false;

    private TextImporter _textImporter;

    private Movement player_Movement;

    void Start()
    {
        _canvas = GameObject.Find("Canvas");
        _textImporter = GetComponent<TextImporter>();
        _canvasController = _canvas.GetComponent<CanvasController>();
        _dialoguebox = _canvasController.dialogueBox.GetComponent<DialogueBox>();
    }

    // Update is called once per frame

    void Update(){
        if(writing)
            if(!_dialoguebox.GetReady()){
                _canvasController.DeActiveDialogueBox();
                _canvasController.ActivePlayerUI();
                player_Movement.SetStopMoving(false);
                Destroy(gameObject);
            }
    }
    void OnTriggerEnter(Collider collision){
        if(collision.gameObject.layer == LayerMask.NameToLayer(layer_name)){
            player_Movement = collision.gameObject.GetComponent<Movement>();
            player_Movement.SetStopMoving(true);
            _canvasController.DeActivatePlayerUI();
            _canvasController.ActiveDialogueBox();
            _dialoguebox.SetTextImporter(_textImporter);
            writing = true;
        }
    }
}
