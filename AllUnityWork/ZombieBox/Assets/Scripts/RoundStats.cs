using UnityEngine;
using System.Collections;
//should be created/ maintained by round manager
public class RoundStats : MonoBehaviour {

    public int ROUND_NUMBER = 1;
    public int NUM_ENEMIES = 10;
    public int BASE_HEALTH = 1000;

    public int ENEMY_HEALTH = 100;
    public int ENEMY_SPAWN_DELAY = 2;
    public int MAX_ENEMIES = 20;
    public int PLAYER_HEALTH = 100;
    public int playerPoints = 0;
    public int total_kills = 0;
    public int roundPoints = 0;
    public int roundKills = 0;
    public int deadEnemies = 0;
    public int gun_kills = 0;
    public int shotgun_kills = 0;
    public int knife_kills = 0;
    public int crowbar_kills = 0;
    public DataManager data;

    public PlayerHealth health;
    public GameObject door;
    public EnemyManager enemyManager;
    public StatUpdater statsGUI;
	public GameObject roundWon;
	public GameObject roundLost;

    void OnTriggerEnter()
    {

        door.SetActive(true);
        enemyManager.spawnRoundNumber(ROUND_NUMBER);
        Destroy(this.GetComponent<BoxCollider>());
    }

    // Use this for initialization
    void Start()
    {
        ROUND_NUMBER = PlayerPrefs.GetInt("round");
        statsGUI.round.text = "" + ROUND_NUMBER;

		NUM_ENEMIES += 5 * ROUND_NUMBER;

        if (ROUND_NUMBER > 1 && ROUND_NUMBER < 10)
        {
            ENEMY_HEALTH += + (10 * ROUND_NUMBER);
        }
        else if (ROUND_NUMBER >= 10)
        {
			ENEMY_HEALTH = (int)(1000.0f * (1.0f + ((float)ROUND_NUMBER) / 10.0f));
            BASE_HEALTH = 100 + 10 * (ROUND_NUMBER - 9);
        }
        playerPoints = PlayerPrefs.GetInt("points_available");
        total_kills = PlayerPrefs.GetInt("total_kills");

    }
    public int getRoundNumber()
    {
        return ROUND_NUMBER;
    }
	// Update is called once per frame
	void Update ()
    {

    }

	public void enemyDied()
	{
		deadEnemies++;
		if (deadEnemies == NUM_ENEMIES)
        {
			StartCoroutine(endRound(true));
        }
	}

	public void playerDied()
	{
		StartCoroutine(endRound(false));
	}

	public void baseDied()
	{
		StartCoroutine(endRound(false));
	}

    IEnumerator endRound(bool win)
    {
        Debug.Log("round over " + roundKills + " " +roundPoints);
		if (win)
		{
			roundWon.SetActive(true);
			if (ROUND_NUMBER + 1 > PlayerPrefs.GetInt("hightestRound"))
			{
				PlayerPrefs.SetInt("highestRound", ROUND_NUMBER + 1);
			}
		}
		else
		{
			roundLost.SetActive(true);
		}
		
		data.savePlayerPrefsGame(roundPoints,total_kills+ roundKills,roundKills,PlayerPrefs.GetString("charID"),gun_kills,shotgun_kills,knife_kills,crowbar_kills);

        StartCoroutine(data.writePlayerPrefs());
        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("GunID"), PlayerPrefs.GetInt("GunDmg"), PlayerPrefs.GetInt("GunAmmo"), PlayerPrefs.GetFloat("GunRate"), PlayerPrefs.GetInt("GunKills")));
        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("ShotgunID"), PlayerPrefs.GetInt("ShotgunDmg"), PlayerPrefs.GetInt("ShotgunAmmo"), PlayerPrefs.GetFloat("ShotgunRate"), PlayerPrefs.GetInt("ShotgunKills")));
        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("KnifeID"), PlayerPrefs.GetInt("KnifeDmg"), PlayerPrefs.GetInt("KnifeAmmo"), PlayerPrefs.GetFloat("KnifeRate"), PlayerPrefs.GetInt("KnifeKills")));
        StartCoroutine(data.writeWeaponStats(PlayerPrefs.GetInt("CrowbarID"), PlayerPrefs.GetInt("CrowbarDmg"), PlayerPrefs.GetInt("CrowbarAmmo"), PlayerPrefs.GetFloat("CrowbarRate"), PlayerPrefs.GetInt("CrowbarKills")));
        StartCoroutine(data.writeSkinStats(PlayerPrefs.GetInt(PlayerPrefs.GetString("charID") + "ID"), PlayerPrefs.GetInt(PlayerPrefs.GetString("charID") + "Kills")));

		

		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel("mainMenu");
    }
}
