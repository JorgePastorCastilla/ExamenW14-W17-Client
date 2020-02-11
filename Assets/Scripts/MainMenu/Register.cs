using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Collections;

public class Register : MonoBehaviour
{
    // Cached references
    public InputField emailInputField;
    public InputField passwordInputField;
    public InputField confirmPasswordInputField;
    public Button registerButton;
    public Text messageBoardText;
    public Player playerManager;

    string httpServer;

    private void Start()
    {
        playerManager = FindObjectOfType<Player>();
        httpServer = playerManager.GetHttpServer();
    }

    public void OnRegisterButtonClick()
    {
        StartCoroutine( RegisterNewUser() );
    }

    private IEnumerator RegisterNewUser()
    {
        if (string.IsNullOrEmpty(emailInputField.text))
        {
            throw new NullReferenceException("Email can't be void");
        }
        else if (string.IsNullOrEmpty(passwordInputField.text))
        {
            throw new NullReferenceException("Password can't be void");
        }
        else if (passwordInputField.text != confirmPasswordInputField.text)
        {
            throw new Exception("Passwords don't match");
        }

        AspNetUserRegister newUser = new AspNetUserRegister();
        newUser.Email = emailInputField.text;
        newUser.Password = passwordInputField.text;
        newUser.ConfirmPassword = confirmPasswordInputField.text;

        UnityWebRequest httpClient = new UnityWebRequest(httpServer + "api/account/register", "POST");

        string jsonDatos = JsonUtility.ToJson(newUser);
        byte[] ReadyData = Encoding.UTF8.GetBytes(jsonDatos);

        httpClient.uploadHandler = new UploadHandlerRaw(ReadyData);
        httpClient.SetRequestHeader("Content-Type", "application/json");

        yield return httpClient.SendWebRequest();

        if (httpClient.isNetworkError || httpClient.isHttpError)
        {
            Debug.Log("La api falla por " + httpClient.responseCode + " : " + httpClient.error);
        }
        messageBoardText.text += "\n" + httpClient.responseCode;

        httpClient.Dispose();

    }

}
