using UnityEngine;
using System.Collections;

public class PlayMusicOnAwake : MonoBehaviour {
    public static PlayMusicOnAwake Instance;

    public AudioClip music;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            Instance = this;
        }
        else
        {
            if (this.music == Instance.music)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(Instance.gameObject);
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }

    void Start()
    {
        audio.Play();
    }
}
