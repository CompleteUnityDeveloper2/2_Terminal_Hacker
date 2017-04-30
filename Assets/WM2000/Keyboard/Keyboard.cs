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
        if (Input.anyKeyDown)
        {
            PlayRandomSound();
            SendFrameInput(Input.inputString);
        }
    }

    private void PlayRandomSound()
    {
        int randomIndex = UnityEngine.Random.Range(0, keyStrokeSounds.Length);
        audioSource.clip = keyStrokeSounds[randomIndex];
        audioSource.Play();
    }

    private void SendFrameInput(string inputThisFrame)
    {
        terminal.ReceiveFrameInput(inputThisFrame);
    }
}
