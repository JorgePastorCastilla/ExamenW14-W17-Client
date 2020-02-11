using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    // Cached references
    public InputField emailInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Button logoutButton;
    public Button playGameButton;
    public Text messageBoardText;
    public Player playerManager;

    private string httpServerAddress;

    private void Start()
    {
        playerManager = FindObjectOfType<Player>();
        httpServerAddress = playerManager.GetHttpServer();
    }

    public void OnLoginButtonClicked()
    {

    }

    private void GetToken()
    {

    }

    private void TryLogin()
    {

    }

    public void OnLogoutButtonClicked()
    {
        TryLogout();
    }

    private void TryLogout()
    {
        UnityWebRequest httpClient = new UnityWebRequest(playerManager.GetHttpServer());

        httpClient.SetRequestHeader("", "" + playerManager.Token);

        if (httpClient.isNetworkError || httpClient.isHttpError)
        {
            Debug.Log(httpClient.error);
        }
        else
        {
            messageBoardText.text += $"\n{httpClient.responseCode} Bye bye {playerManager.PlayerId}.";
            playerManager.Token = string.Empty;
            playerManager.PlayerId = string.Empty;
            playerManager.Email = string.Empty;
            loginButton.interactable = true;
            logoutButton.interactable = false;
            playGameButton.interactable = false;
        }
    }
}
