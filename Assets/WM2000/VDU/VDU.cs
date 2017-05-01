using UnityEngine;
using UnityEngine.UI;

public class VDU : MonoBehaviour
{
    [SerializeField] Terminal terminal;

    // TODO calculate these two if possible
    [SerializeField] int charactersWide = 40;
    [SerializeField] int charactersHigh = 14;

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