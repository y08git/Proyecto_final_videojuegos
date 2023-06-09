using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelEvent : MonoBehaviour
{
    // Start is called before the first frame update
    ScenesManager _sceneManager;
    void Start()
    {
        _sceneManager = GetComponent<ScenesManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider Other){
        if(LayerMask.NameToLayer("Player") == Other.gameObject.layer){
            _sceneManager.LoadNextScene();
        }
    }
}
