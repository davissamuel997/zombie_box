using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;
using System.Text;
public class LoginMenu : MonoBehaviour
{

    public static GameObject selected;
    public CanvasGroup canvasGroup;
    public bool init_flag = true;
    private Button loginButton;
    private InputField usernameInput;
    private InputField passwordInput;
    private WWW webCall;
    private string user_name;
    private string password;
    const string GET_STATS = "get_user_stats?user_id=";
    const string VERIFY_LOGIN = "verify_user_login?email=";
    const string ROOT_URL = "https://nameless-harbor-4730.herokuapp.com/";
    const string POST_URL = "update_all_user_details";
    void Start()
    {
        usernameInput = GameObject.Find("usernameTxt").GetComponent<InputField>();
        passwordInput = GameObject.Find("password").GetComponent<InputField>();
        StartCoroutine("writePlayerPrefs");
    }
    IEnumerator getLogin()
    {
        webCall = new WWW(ROOT_URL + VERIFY_LOGIN + user_name + "&password=" + password);
        yield return webCall;
        Debug.Log(webCall.text);
        var data = JSON.Parse(webCall.text);

        if (data["errors"].AsBool)
        {
            Debug.Log("Invalid Credentials");
            passwordInput.text = "";
            yield break;
        }
        else
        {
            int uid = data["user"]["user_id"].AsInt;
            Debug.Log("USER ID: ==" + uid);
            PlayerPrefs.SetInt("user_id", uid);

            int points = data["user"]["total_points"].AsInt;
            PlayerPrefs.SetInt("total_points", points);
            Debug.Log("total_points: ==" + points);

            int kills = data["user"]["total_kills"].AsInt;
            PlayerPrefs.SetInt("total_kills", kills);
            Debug.Log("total_kills: ==" + kills);

            for (int i = 0; i < 4; i++)
            {
                string weapon_name = data["user"]["weapons"][i]["name"];
                Debug.Log(weapon_name);
                int damage = data["user"]["weapons"][i]["damage"].AsInt;
                Debug.Log(damage);
                int ammo = data["user"]["weapons"][i]["ammo"].AsInt;
                Debug.Log(ammo);
                kills = data["user"]["weapons"][i]["kill_count"].AsInt;
                Debug.Log(kills);
                PlayerPrefs.SetInt(weapon_name + "Dmg", damage);
                PlayerPrefs.SetInt(weapon_name + "Ammo", ammo);
                PlayerPrefs.SetInt(weapon_name + "Kills", i);
            }
            for (int i = 0; i <9; i++)
            {
                string skin_name = data["user"]["skins"][i]["name"];
                Debug.Log(skin_name);
                kills = data["user"]["skins"][i]["kill_count"].AsInt;
                Debug.Log(kills);
                PlayerPrefs.SetInt(skin_name + "Kills", i);
     

            }
            Debug.Log("web done");

            Application.LoadLevel("mainMenu");
        }
    }

    void writePlayerPrefs()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        string str = "{user_id:1,total_points: 1000,total_kills:3000}";
        headers.Add("Accept", "application/json");
        headers.Add("Content-Type", "text/json");
        byte[] data = Encoding.UTF8.GetBytes(str);
        WWW www = new WWW(ROOT_URL + POST_URL, data);


        StartCoroutine(WaitForRequest(www));
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW NOT OK!: " + www.text);
            Debug.Log("WWW Error: " + www.error);
            foreach (KeyValuePair<string, string> headers in www.responseHeaders)
            {
                Debug.Log(headers.Key + " " + headers.Value);
            }
        }
    }
    void Update()
    {

    }

    public void login()
    {
        user_name = usernameInput.text;
        password = passwordInput.text;
        StartCoroutine("getLogin");
        Debug.Log("loging in");


    }
}
