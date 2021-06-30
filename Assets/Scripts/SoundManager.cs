using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;

    public AudioClip goalBloop;
    public AudioClip lossBuzz;
    public AudioClip HitPaddleBloop;
    public AudioClip winSound;
    public AudioClip wallBloop;

    private AudioSource _soundEffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource[] sources = GetComponents<AudioSource>();

        foreach (AudioSource source in sources)
        {
            if (source.clip == null)
            {
                _soundEffectAudio = source;
            }
        }
    }

    public void PlayOneShot(AudioClip clip)
    {
        _soundEffectAudio.PlayOneShot(clip);
    }
}
