using UnityEngine;

public class Player : MonoBehaviour
{
    private const string httpServer = "https://localhost:44341/";
    //private const string httpServer = "http://clickycrateswebapijpc.azurewebsites.net/";


    public string GetHttpServer()
    {
        return httpServer;
    }

    private string _token;
    public string Token
    {
        get { return _token; }
        set { _token = value; }
    }

    private string _playerId;
    public string PlayerId
    {
        get { return _playerId; }
        set { _playerId = value; }
    }

    private string _email;
    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

}
