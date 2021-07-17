using UnityEngine;

/// <summary>
/// Class showing usage example.
/// Uses UI and server communication.
/// </summary>
public class UsageExample : MonoBehaviour
{
    // Reference to the servercommunication
    [SerializeField]
    private ServerCommunication communication;

    // Reference to UIForm
    [SerializeField]
    private UIForm uiForm;

    /// <summary>
    /// Unity method called after object initialization.
    /// </summary>
    private void Start()
    {
        communication.Lobby.OnConnectedToServer += OnConnectedToServer;
        communication.ConnectToServer();
    }

    /// <summary>
    /// Method called after connection with server was established.
    /// </summary>
    private void OnConnectedToServer()
    {
        communication.Lobby.OnConnectedToServer -= OnConnectedToServer;

        communication.Lobby.OnEchoMessage += OnReceivedEchoMessage;
        uiForm.OnSendButtonClicked += OnSendForm;
    }

    /// <summary>
    /// Method called when Send button was clicked in form.
    /// Send echo message to the server.
    /// </summary>
    public void OnSendForm()
    {/*
        var message = new EchoMessageModel
        {
            text = uiForm.InputFieldText
        };
        communication.Lobby.EchoMessage(message);
        */
        communication.client.Send(uiForm.InputFieldText);
        uiForm.ClearInputField();
    }

    /// <summary>
    /// Method called when server return echo message.
    /// </summary>
    /// <param name="message">Message.</param>
    private void OnReceivedEchoMessage(EchoMessageModel message)
    {
        //Debug.Log("Echo message received: " + message.text);
        uiForm.ShowServerResponse(message.text);
    }

    /// <summary>
    /// Unity method called when object is disabled.
    /// </summary>
    private void OnDisable()
    {
        communication.Lobby.OnConnectedToServer -= OnConnectedToServer;
        communication.Lobby.OnEchoMessage -= OnReceivedEchoMessage;

        uiForm.OnSendButtonClicked -= OnSendForm;
    }
}
