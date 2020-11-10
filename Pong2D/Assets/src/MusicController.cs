using UnityEngine;

///////////////////////////////////////////////////////////////////
///                     MusicController.cs
///          DontDestroyOnLoad setup for music instance in game.
///////////////////////////////////////////////////////////////////
public class MusicController : MonoBehaviour
{
    private static MusicController _instance;

    void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}