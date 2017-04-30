using UnityEngine;
using UnityEngine.UI;

public class VDU : MonoBehaviour
{
    [SerializeField] Terminal terminal;
    [SerializeField] int charactersWide, charactersHigh; // TODO calculate if possible

    Text screenText;

    private void Awake()
    {
        screenText = GetComponent<Text>();
    }

    // Akin to monitor refresh
    private void Update()
    {
        screenText.text = terminal.GetDisplayBuffer(charactersWide, charactersHigh);
    }
}