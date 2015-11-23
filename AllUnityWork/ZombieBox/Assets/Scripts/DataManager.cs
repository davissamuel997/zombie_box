using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;
using System.Text;

public class DataManager : MonoBehaviour {

    const string GET_STATS = "get_user_stats?user_id=";
    const string VERIFY_LOGIN = "verify_user_login?email=";
    const string ROOT_URL = "https://nameless-harbor-4730.herokuapp.com/";
    const string POST_USER_URL = "update_all_user_details";
    const string POST_WEAPON_URL = "update_weapon_stats";
    const string POST_SKIN_URL = "update_skin_stats";
    Upgrader upgrades;
    bool done_flag = false;
    void Start()
    {
        
    }
    void postCall(string str)
    {
        StartCoroutine(str);
    }
    public void savePlayerPrefsGame(int points,int total_kills, int kills,string skin, int gun_kills, int shotgun_kills, int knife_kills, int crowbar_kills)
    {
        PlayerPrefs.SetInt("points_available", points);
        PlayerPrefs.SetInt("total_kills", total_kills);
        PlayerPrefs.SetInt(skin + "Kills", kills);

        PlayerPrefs.SetInt("GunKills", gun_kills);
        PlayerPrefs.SetInt("ShotgunKills", shotgun_kills);
        PlayerPrefs.SetInt("KnifeKills", knife_kills);
        PlayerPrefs.SetInt("CrowbarKills", crowbar_kills);


    }
    public void savePlayerPrefsMenu(float r, float g, float b)
    {
        
        upgrades = GameObject.Find("Upgrader").GetComponent<Upgrader>();
        PlayerPrefs.SetFloat("BaseRed", r);
        PlayerPrefs.SetFloat("BaseGreen", g);
        PlayerPrefs.SetFloat("BaseBlue", b);

        PlayerPrefs.SetInt("total_points", upgrades.points);

        PlayerPrefs.SetInt("GunAmmo", upgrades.gunAmmo);
        PlayerPrefs.SetInt("GunDmg", upgrades.gunDmg);
    
        PlayerPrefs.SetInt("ShotgunAmmo", upgrades.shotgunAmmo);
        PlayerPrefs.SetInt("ShotgunDmg", upgrades.shotgunDmg);
       
        PlayerPrefs.SetInt("KnifeDmg", upgrades.knifeDmg);

        PlayerPrefs.SetInt("CrowbarDmg", upgrades.crowbarDmg);

        PlayerPrefs.SetFloat("TurretRate", upgrades.turretRate);
        PlayerPrefs.SetInt("TurretDmg", upgrades.turretDmg);

        Debug.Log(upgrades.points);

    }
   
    public IEnumerator writePlayerPrefs()
    {
        JSONClass root = new JSONClass();
        JSONClass users = new JSONClass();
        JSONClass wep = new JSONClass();
        JSONClass wep2 = new JSONClass();
        JSONArray weapons = new JSONArray();
        users.Add("user_id", ""+ PlayerPrefs.GetInt("user_id"));
        users.Add("total_kills", ""+ PlayerPrefs.GetInt("total_kills"));
        users.Add("total_points", ""+ PlayerPrefs.GetInt("total_points"));
        users.Add("red", "" + PlayerPrefs.GetFloat("BaseRed"));
        users.Add("green", "" + PlayerPrefs.GetFloat("BaseGreen"));
        users.Add("blue", "" + PlayerPrefs.GetFloat("BaseBlue"));
        users.Add("highest_round_reached", "" + PlayerPrefs.GetInt("highestRound"));
        root.Add("user_params", users);
        

        Debug.Log(root.ToString());
        byte[] data = Encoding.UTF8.GetBytes(root.ToString());
        WWW www = new WWW(ROOT_URL + POST_USER_URL, data);
       yield return WaitForRequest(www);
    }
    public bool isDone()
    {
        return done_flag;
    }
    public IEnumerator writeWeaponStats(int id, int damage, int ammo, float rate, int kills)
    {
        JSONClass root = new JSONClass();
        JSONClass weapon = new JSONClass();

        weapon.Add("weapon_id", "" + id);
        weapon.Add("damage", "" + damage);
        weapon.Add("ammo", "" + ammo);
        weapon.Add("fire_rate", "" + rate);
        weapon.Add("kill_count", "" + kills);
        root.Add("weapon_params", weapon);

        Debug.Log(root.ToString());
        byte[] data = Encoding.UTF8.GetBytes(root.ToString());
        WWW www = new WWW(ROOT_URL + POST_WEAPON_URL, data);

        yield return WaitForRequest(www);
    }

    public IEnumerator writeSkinStats(int id, int kills)
    {

        JSONClass root = new JSONClass();
        JSONClass weapon = new JSONClass();

        weapon.Add("skin_id", "" + id);
        weapon.Add("kill_count", "" + kills);
        root.Add("skin_params", weapon);

        Debug.Log(root.ToString());
        byte[] data = Encoding.UTF8.GetBytes(root.ToString());
        WWW www = new WWW(ROOT_URL + POST_SKIN_URL, data);

        yield return WaitForRequest(www);
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
}
