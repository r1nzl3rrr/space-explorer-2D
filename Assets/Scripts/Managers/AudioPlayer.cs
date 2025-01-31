using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] 
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;
    
    [Header("Pickup")]
    [SerializeField] AudioClip pickupClip;
    [SerializeField] [Range(0f, 1f)] float pickupVolume = 1f;
    
    [SerializeField] AudioClip[] songs; 
    [SerializeField] [Range(0f, 1f)] float songVolume = 1f;

    int currentSongIndex = 0;
    AudioSource audioSource;
    
    static AudioPlayer _instance;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // Play the first song on start
        if (songs.Length > 0)
        {
            PlayCurrentSong();
        }
    }

    void Awake()
    {
        ManageSingleton();
    }
    
    void Update()
    {
        // Continuously check if the song is playing and switch to the next one
        CheckAndPlayNextSong();
    }

    void PlayCurrentSong()
    {
        // Set the current song and play it
        audioSource.clip = songs[currentSongIndex];
        audioSource.volume = songVolume;
        audioSource.Play();
    }

    void CheckAndPlayNextSong()
    {
        // Check if the current song is finished playing
        if (!audioSource.isPlaying)
        {
            // Move to the next song and play it
            currentSongIndex = (currentSongIndex + 1) % songs.Length;
            PlayCurrentSong();
        }
    }

    // Applying singleton pattern
    void ManageSingleton()
    {
        if (_instance)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }
    
    public void PlayPickupClip()
    {
        PlayClip(pickupClip, pickupVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip)
        {
            // Play audio clip at camera with defined volume
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
