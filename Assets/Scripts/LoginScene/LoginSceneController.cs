using UnityEngine;
using UnityEngine.UI;

public class LoginSceneController : MonoBehaviour
{
    public InputField UserNameInput;
    public InputField PasswordInput;
    public Button LoginButton;

    private DataStash dataStash;

    void Start()
    {
        //initialize
        LoginButton.onClick.AddListener(OnLoginBtnClicked);
        dataStash = DataStash.GetInstance();  
    }

    void Update()
    {
        
    }

    void OnLoginBtnClicked()
    {
         if (UserNameInput.text != "" && PasswordInput.text != "")
         {
            LoginButton.enabled = false;

            Debug.Log(string.Format("Loggging in to AccelByte with user name: {0} and password: {1}", UserNameInput.text, PasswordInput.text));
            var accelByteUser = dataStash.GetAccelByteUser();
            accelByteUser.LoginWithUsername(UserNameInput.text, PasswordInput.text,
                result =>
                {
                    if (result.IsError)
                    {
                        Debug.Log("Login failed");
                        LoginButton.enabled = true;
                    }
                    else
                    {
                        Debug.Log("Login successful");
                        //switch scene
                    }
                });                
        }
    }
}
