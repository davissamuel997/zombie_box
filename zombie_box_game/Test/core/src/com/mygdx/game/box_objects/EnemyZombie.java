package com.mygdx.game.box_objects;

import com.badlogic.gdx.graphics.g3d.Model;
import com.badlogic.gdx.math.Vector3;

///////////////////////////////////////////////////////////////////////////////////////////////////
/* Created by Eric on 9/3/2015.
*
* Class: EnemyZombie extends Enemy
*
* NOTES: This is an enemy that paths to the Player or Base and does mele attacks
*
* Should have specific stats and texture
*
*
*//////////////////////////////////////////////////////////////////////////////////////////////////
public class EnemyZombie extends Enemy
{
    public static final int BASE_HEALTH = 100;
    public static final float BASE_MS = 10f;
    public static final int BASE_DMG = 10;
    public final String path = "data/zombie1.g3db";
    private static boolean firstLoaded = true;
    private Model model;
    public EnemyZombie()
    {
        super(BASE_HEALTH, BASE_DMG, BASE_MS);
        if(firstLoaded)
        {
            addAssets(path);
            while (!waitLoad()) ;
        }
        firstLoaded = false;
        model = loadModel(path);
        setModelInstance(model,new Vector3(100,125,100),new Vector3(0, 0, 1),90);
    }

}
