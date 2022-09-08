using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Static instance
    private static AudioManager instance;
    public static AudioManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawn AudioManager", typeof(AudioManager)).GetComponent<AudioManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    public AudioSource musicSource;
    public AudioSource musicSource2;
    [SerializeField]
    private GameObject[] sfxSource;
    public Sounds[] sounds;

    public float a;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        musicSource = this.gameObject.AddComponent<AudioSource>();
        musicSource2 = this.gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource2.loop = true;

      /*  for (int i = 0; i < sfxSource.Length; i++)
        {
            sfxSource[i].AddComponent<AudioSource>();
            sfxSource[i].GetComponent<AudioSource>().clip = sounds[i];
            sfxSource[i].GetComponent<AudioSource>().volume = a;
        }
        */
    }

    public void Play(string name)
    {
        
    }
    public GameObject SelecSfx(GameObject source, int indice, float volumen, bool loop, float blend)
    {
        source.GetComponent<AudioSource>().clip = sounds[indice].source.clip;
        source.GetComponent<AudioSource>().volume = volumen;
        source.GetComponent<AudioSource>().loop = loop;
        source.GetComponent<AudioSource>().spatialBlend = blend;
        source.GetComponent<AudioSource>().Play();

        return source;

    }
    public void ChangeMasterVolumen(float value)
    {
        AudioListener.volume = value;
    }
    /*
    public void ChangeVolumenSfx(float value)
    {/*
        for (int i = 0; i <= sfxSound.Length; i++)
        {
            sfxSource[i].GetComponent<AudioSource>().volume = value;
        }
        
        a = value;
    }
    public void ChangeVolumenMusic(float value)
    {
        musicSource.GetComponent<AudioSource>().volume = value;
        musicSource2.GetComponent<AudioSource>().volume = value;
    }
        */
}
