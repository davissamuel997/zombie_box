using UnityEngine;
using System.Collections;

public class StatsObject
{
    private string first_name;
    private string last_name;
    private int id;
    private int kills;
    private int shots_fired;
    private int hits;




    public StatsObject(string f, string l, int num, int k, int fire, int h)
    {
        first_name = f;
        last_name = l;
        id = num;
        kills = k;
        shots_fired = fire;
        hits = h;
    }
    
}
