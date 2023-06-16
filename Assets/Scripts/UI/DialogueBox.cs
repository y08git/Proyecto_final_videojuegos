using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private GameObject text;
    private TextMeshProUGUI _text;
    private string[] dialogue;

    private int line = -1;
    private bool ready = false;
    private TextImporter _textImporter;
    void Start()
    {
        _text = text.GetComponent<TextMeshProUGUI>();
        _text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(ready){
            if(Input.GetKeyDown("n")){
                SetNextLine();
            }
        }
    }

    public void SetTextImporter(TextImporter textImporter){
        _textImporter = textImporter;
        line = 0;
        SetNextLine();
        ready = true;
    }

    private void SetNextLine(){
         if(line < _textImporter.GetEndLine()){
            _text.text = _textImporter.GetTextLines()[line];
            line += 1;
        }
        else
            Clear();
    }

    private void Clear(){
        ready = false;
        line = -1;
        _text.text = "";
        _textImporter = null;
    }

    public bool GetReady(){
        return ready;
    }
}
