using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] AudioClip[] keyStrokeSounds;
    [SerializeField] Terminal terminal;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool isValidKey = Input.inputString.Length > 0;
        if (isValidKey)
        {
            PlayRandomSound();
            terminal.ReceiveFrameInput(Input.inputString);
        }
    }

    private void PlayRandomSound()
    {
        int randomIndex = UnityEngine.Random.Range(0, keyStrokeSounds.Length);
        audioSource.clip = keyStrokeSounds[randomIndex];
        audioSource.Play();
    }
}
