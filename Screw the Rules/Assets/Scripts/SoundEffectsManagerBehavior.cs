using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectsManagerBehavior : MonoBehaviour
{
    #region The Dreaded Singleton
    public static SoundEffectsManagerBehavior instance;
    #endregion

    #region Fields
    [SerializeField] AudioClip sfxCorrect, sfxWrong;
    #endregion

    #region Members
    AudioSource m_MyAudioSource;
    #endregion

    #region Methods
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        m_MyAudioSource = GetComponent<AudioSource>();
    }

    public void PlayWinNoise()
    {
        if (instance == null)
            return;

        if (m_MyAudioSource.isPlaying)
            m_MyAudioSource.Stop();
        m_MyAudioSource.PlayOneShot(sfxCorrect);
    }

    public void PlayLoseNoise()
    {
        if (instance == null)
            return;

        if (m_MyAudioSource.isPlaying)
            m_MyAudioSource.Stop();
        m_MyAudioSource.PlayOneShot(sfxWrong);
    }
    #endregion
}
