using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;


using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


public class SignUp : MonoBehaviour
{

    #region Variables 
    [Header("Sign Up")]
    public TMP_InputField SignUp_userNameText;
    public TMP_InputField SignUp_userEmailText;
    public TMP_InputField SignUp_userPasswordText;
    public TMP_InputField SignUp_userConfirmPasswordText;

    string createUserURL = "http://localhost/squealsystem/InsertUser.php";

    [Header("Log In")]
    public TMP_InputField LogIn_userNameText;
    public TMP_InputField LogIn_userPasswordText;

    string loginUserURL = "http://localhost/squealsystem/LoginUser.php";

    string inputUserName;
    string inputEmail;
    string inputPassword;


    #endregion

    #region SignUp
    public void SubmitSignUpInfo()
    {
        if (SignUp_userPasswordText.text == SignUp_userConfirmPasswordText.text)
        {
            inputUserName = SignUp_userNameText.text;
            inputEmail = SignUp_userEmailText.text;
            inputPassword = SignUp_userPasswordText.text;

            StartCoroutine(CreateUser(inputUserName, inputEmail, inputPassword));
        }
        else
        {
            print("Passwords do not match");
        }
        
    }

    IEnumerator CreateUser(string username, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);
        yield return webRequest.SendWebRequest();
        

        string returnInfoString = webRequest.downloadHandler.text;
        print(returnInfoString);

    }
    #endregion
    #region Login 
    public void SubmitLoginInfo()
    {
        inputUserName = LogIn_userNameText.text;
        inputPassword = LogIn_userPasswordText.text;

        StartCoroutine(LogInUser(inputUserName, inputPassword));
    }

    IEnumerator LogInUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        UnityWebRequest webRequest = UnityWebRequest.Post(loginUserURL, form);
        yield return webRequest.SendWebRequest();

        string returnInfoString = webRequest.downloadHandler.text;
        print(returnInfoString);

        if(returnInfoString == "Login Success")
        {
            print("Login Success");
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
