using UnityEngine;
using UnityEngine.Assertions;

public class Keyboard : MonoBehaviour
{
    [SerializeField] AudioClip[] keyStrokeSounds;
    [SerializeField] Terminal terminal;

    AudioSource audioSource;
    bool isPluggedIn = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        QualitySettings.vSyncCount = 0; // No V-Sync so Update() not held back by render
        Application.targetFrameRate = 1000; // To minimise delay playing key sounds
        CheckIfPluggedIn();
    }

    private void CheckIfPluggedIn()
    {
        if (terminal)
        {
            isPluggedIn = true;
        }
        else
        {
            Debug.LogWarning("Keyboard not connected to a terminal");
        }
    }

    private void Update()
    {
        bool isValidKey = Input.inputString.Length > 0;
        if (isValidKey)
        {
            PlayRandomSound();
        }
        if (isPluggedIn)
        {
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
