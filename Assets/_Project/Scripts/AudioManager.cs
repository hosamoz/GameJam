using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource screamSource;
    [SerializeField] List<AudioClip> screamClips = new List<AudioClip>();
    [SerializeField] AudioClip messire;
    [SerializeField] AudioClip sheeesh;

    void Awake()
    {
        screamSource.PlayOneShot(messire, 1f);
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

    public void ssheeshSFX()
    {
        screamSource.PlayOneShot(sheeesh, 10f);
    }
}
