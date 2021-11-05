using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource screamSource;
    [SerializeField] List<AudioClip> screamClips = new List<AudioClip>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void screamSFX() 
    {
        AudioClip clip = screamClips[Random.Range(0, screamClips.Count)];

        screamSource.PlayOneShot(clip, 0.50f);
    }
}
