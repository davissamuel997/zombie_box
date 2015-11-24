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
    public InputField usernameInput;
    public InputField passwordInput;
    private WWW webCall;
    private string user_name;
    private string password;
    const string GET_STATS = "get_user_stats?user_id=";
    const string VERIFY_LOGIN = "verify_user_login?email=";
    const string ROOT_URL = "https://nameless-harbor-4730.herokuapp.com/";
    const string POST_USER_URL = "update_all_user_details";
    const string POST_WEAPON_URL = "update_weapon_stats";
    const string POST_SKIN_URL = "update_skin_stats";

    void Start()
    {
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

            int points = data["user"]["points_available"].AsInt;
            PlayerPrefs.SetInt("points_available", points);
            Debug.Log("points_available: ==" + points);

            int kills = data["user"]["total_kills"].AsInt;
            PlayerPrefs.SetInt("total_kills", kills);

			int high = data["user"]["highest_round_reached"].AsInt;
			PlayerPrefs.SetInt("highestRound",high);

            float r = data["user"]["red"].AsFloat;
            float g = data["user"]["green"].AsFloat;
            float b = data["user"]["blue"].AsFloat;
            PlayerPrefs.SetFloat("BaseRed", r);
            PlayerPrefs.SetFloat("BaseGreen", g);
            PlayerPrefs.SetFloat("BaseBlue", b);

            Debug.Log("total_kills: ==" + kills);

            for (int i = 0; i < 5; i++)
            {
                string weapon_name = data["user"]["weapons"][i]["name"];
                Debug.Log(weapon_name);
                int damage = data["user"]["weapons"][i]["damage"].AsInt;
                Debug.Log(damage);
                int ammo = data["user"]["weapons"][i]["ammo"].AsInt;
                Debug.Log(ammo);
                kills = data["user"]["weapons"][i]["kill_count"].AsInt;
                Debug.Log(kills);
                float rate = data["user"]["weapons"][i]["fire_rate"].AsFloat;
                Debug.Log(rate);
                int  id = data["user"]["weapons"][i]["weapon_id"].AsInt;
                Debug.Log(kills);
                PlayerPrefs.SetInt(weapon_name + "Dmg", damage);
                PlayerPrefs.SetInt(weapon_name + "Ammo", ammo);
                PlayerPrefs.SetFloat(weapon_name + "Rate", rate);
                PlayerPrefs.SetInt(weapon_name + "Kills", kills);
                PlayerPrefs.SetInt(weapon_name + "ID", id);

            }
            for (int i = 0; i <9; i++)
            {
                string skin_name = data["user"]["skins"][i]["name"];
                Debug.Log(skin_name);
                int id = data["user"]["skins"][i]["skin_id"].AsInt;
                Debug.Log(id);
                kills = data["user"]["skins"][i]["kill_count"].AsInt;
                Debug.Log(kills);
                PlayerPrefs.SetInt(skin_name + "Kills", kills);
                PlayerPrefs.SetInt(skin_name + "ID", id);
            }
            Debug.Log("web done");
            
            Application.LoadLevel("mainMenu");
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
