using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("AUDIO SOURCES")]
    // [SerializeField] private AudioSource soundObject;    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("AUDIO CLIPS")]
    public AudioClip backgroundMusic;
    public AudioClip timerSound;
    public AudioClip buttonSound;
    public AudioClip tokenSound;
    public AudioClip gemSound;
    public AudioClip keySound;
    public AudioClip doorLockedSound;
    public AudioClip doorOpeningSound;
    public AudioClip injuredSound;

    [Header("VOLUME CONTROLS")]
    [SerializeField] private  float musicVolume;
    [SerializeField] private  float sfxVolume;    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        musicVolume = 0.2f;
        sfxVolume = 1f;
    }

    private void Start()
    {
        //Specify audioSource for background music
        musicSource.clip = backgroundMusic;

        //Set background music volume and play music
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void PlaySoundFXClip (AudioClip audioClip, Transform transform)
    {
        //Specify audioSource for sound effects
        AudioSource audioSource = sfxSource;

        //Assign audioClip
        audioSource.clip = audioClip;

        //Set sound effects volume and play clip
        audioSource.volume = sfxVolume;
        audioSource.Play();
    }

    // public void PlaySoundClip (AudioClip audioClip, Transform transform, float volume)
    // {
    //     //Create AudioSource gameObject
    //     AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

    //     //Assign audioClip
    //     audioSource.clip = audioClip;

    //     //Set sound effects volume
    //     audioSource.volume = volume;

    //     //Play clip
    //     audioSource.Play();

    //     //Destroy AudioSource
    //     float clipLength = audioSource.clip.length;
    //     Destroy(audioSource.gameObject, clipLength);
    // }
}
