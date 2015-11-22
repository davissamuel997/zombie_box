using UnityEngine;
using System.Collections;

public class BoxStats : MonoBehaviour {

    TextMesh text;
    Transform dmg_box;
    Transform amo_box;
    public Upgrader temp;
    // Use this for initialization
    void Start()
    {
        text = this.GetComponentInChildren<TextMesh>();
        dmg_box = GameObject.Find("DmgCap").transform;
        amo_box = GameObject.Find("AmoCap").transform;

    }
   
    public void updateText(string str)
    {
        text.text = str;

    }
    // Update is called once per frame
    void Update()
    {
        updateText(temp.name);
        
    }
}
