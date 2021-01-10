using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance ;
    void Awake()
    {
        if (!_instance)
        {
            _instance = this ;  
        }

        else
        {
            Destroy(this.gameObject) ;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/MUSIC/Good for Nothing Safety");
    }
}
