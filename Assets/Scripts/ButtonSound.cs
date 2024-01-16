using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound; // Dźwięk kliknięcia przycisku
    private AudioSource audioSource;

    [Range(0f, 1f)]
    public float volume = 1f; // Głośność dźwięku
    public float pitch = 1f; // Ton dźwięku
    public float duration = 1f; // Czas trwania dźwięku

    void Start()
    {
        // Inicjalizacja AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayButtonClickSound()
    {
        if (clickSound != null)
        {
            // Ustawianie parametrów dźwięku
            audioSource.clip = clickSound;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(clickSound);

            // Automatyczne zniszczenie obiektu AudioSource po czasie trwania dźwięku
            // Destroy(audioSource, duration);
        }
        else
        {
            Debug.LogWarning("Nieprzypisano dźwięku do skryptu.");
        }
    }
}
