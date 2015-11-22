using UnityEngine;
using System.Collections;

public class killStats : MonoBehaviour {

    private TextMesh kills0;
    private TextMesh kills1;
    private TextMesh kills2;
    private TextMesh kills3;
    private TextMesh kills4;
    private TextMesh kills5;
    private TextMesh kills6;
    private TextMesh kills7;
    private TextMesh kills8;

    private TextMesh gunKills;
    private TextMesh shotgunKills;
    private TextMesh knifeKills;
    private TextMesh crowbarKills;
    // Use this for initialization
    void Start ()
    {
        kills0=  GameObject.Find("00Kills").GetComponent<TextMesh>();
        kills0.text = "Kills: " + PlayerPrefs.GetInt("00Kills");

        kills1 = GameObject.Find("01Kills").GetComponent<TextMesh>();
        kills1.text = "Kills: " + PlayerPrefs.GetInt("01Kills");

        kills2 = GameObject.Find("02Kills").GetComponent<TextMesh>();
        kills2.text = "Kills: " + PlayerPrefs.GetInt("02Kills");

        kills3 = GameObject.Find("03Kills").GetComponent<TextMesh>();
        kills3.text = "Kills: " + PlayerPrefs.GetInt("03Kills");

        kills4 = GameObject.Find("04Kills").GetComponent<TextMesh>();
        kills4.text = "Kills: " + PlayerPrefs.GetInt("04Kills");

        kills5 = GameObject.Find("05Kills").GetComponent<TextMesh>();
        kills5.text = "Kills: " + PlayerPrefs.GetInt("05Kills");

        kills6 = GameObject.Find("06Kills").GetComponent<TextMesh>();
        kills6.text = "Kills: " + PlayerPrefs.GetInt("06Kills");

        kills7 = GameObject.Find("07Kills").GetComponent<TextMesh>();
        kills7.text = "Kills: " + PlayerPrefs.GetInt("07Kills");

        kills8 = GameObject.Find("08Kills").GetComponent<TextMesh>();
        kills8.text = "Kills: " + PlayerPrefs.GetInt("08Kills");


        gunKills = GameObject.Find("gunKills").GetComponent<TextMesh>();
        gunKills.text = "Kills: " + PlayerPrefs.GetInt("GunKills");

        shotgunKills = GameObject.Find("shotgunKills").GetComponent<TextMesh>();
        shotgunKills.text = "Kills: " + PlayerPrefs.GetInt("ShotgunKills");

        knifeKills = GameObject.Find("knifeKills").GetComponent<TextMesh>();
        knifeKills.text = "Kills: " + PlayerPrefs.GetInt("KnifeKills");

        crowbarKills = GameObject.Find("crowbarKills").GetComponent<TextMesh>();
        crowbarKills.text = "Kills: " + PlayerPrefs.GetInt("CrowbarKills");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
