public class InputBuffer
{
    string currentInputLine;

    public delegate void OnCommandSentHandler(string command);
    public event OnCommandSentHandler onCommandSent;

    public void ReceiveFrameInput(string input)
    {
        foreach (char c in input)
        {
            UpdateCurrentInputLine(c);
        }
    }

    public string GetCurrentInputLine()
    {
        return currentInputLine;
        // unless password
    }

    private void UpdateCurrentInputLine(char c)
    {
        if (c == '\b' && currentInputLine.Length > 0)
        {
            currentInputLine = currentInputLine.Remove(currentInputLine.Length - 1);
        }
        else if (c == '\n' || c == '\r')
        {
            SendCommand(currentInputLine); 
        }
        else
        {
            currentInputLine += c;
        }
    }

    private void SendCommand(string command)
    {
        onCommandSent(command);
        currentInputLine = "";
    } 
}
