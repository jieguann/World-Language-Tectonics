using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// UI form class used for example purposes.
/// </summary>
public class UIForm : MonoBehaviour
{
    #region [Input Field]

    // Reference to the input field
    [SerializeField]
    private TMP_InputField inputField;

    // Shortcut to get value from input field
    public string InputFieldText => inputField.text;

    /// <summary>
    /// Clears the input field.
    /// </summary>
    public void ClearInputField()
    {
        inputField.text = "";
    }

    #endregion

    #region [Send Button]

    // Action called on Send button clicked
    public UnityAction OnSendButtonClicked;

    /// <summary>
    /// Method attached to the Send button.
    /// </summary>
    public void SendButtonClicked()
    {
        OnSendButtonClicked?.Invoke();
    }

    #endregion

    #region [Server Response]

    [SerializeField]
    private TextMeshProUGUI serverResponse;

    /// <summary>
    /// Sets label with server response
    /// </summary>
    /// <param name="message">Message.</param>
    public void ShowServerResponse(string message)
    {
        serverResponse.text = $"Server Response:\n{message}";
    }

    #endregion
}
