using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour
{
    // Start is called before the first frame update

    public TextAsset textFile;
    private string[] textLines;

    private int endLine;
    void Start()
    {
        if(textFile != null){
            textLines = (textFile.text.Split('\n'));
            endLine = textLines.Length;
        }
    }

    public string[] GetTextLines(){
        return textLines;
    }

    public int GetEndLine(){
        return endLine;
    }
}
