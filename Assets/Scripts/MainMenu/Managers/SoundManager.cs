using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource soundObject;
    
    // [SerializeField] private AudioSource musicSource;
    // [SerializeField] private AudioSource sfxSource;

    // public AudioClip backgroundMusic;
    public AudioClip buttonSound;
    public AudioClip tokenSound;
    public AudioClip gemSound;
    public AudioClip keySound;
    public AudioClip doorLockedSound;
    public AudioClip doorOpeningSound;
    public AudioClip injuredSound;

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
    }

    private void Start()
    {
        // musicSource.clip = backgroundMusic;
        // musicSource.Play();
    }

    public void PlaySoundClip (AudioClip audioClip, Transform transform, float volume)
    {
        //Create AudioSource gameObject
        AudioSource audioSource = Instantiate(soundObject, transform.position, Quaternion.identity);

        //Assign audioClip
        audioSource.clip = audioClip;

        //Assign volume
        audioSource.volume = volume;

        //Play clip
        audioSource.Play();

        //Destroy AudioSource
        float clipLength = audioSource.clip.length;
        Destroy(audioSource.gameObject, clipLength);
    }
}
