package com.mygdx.game.box_objects;

import com.badlogic.gdx.assets.AssetManager;
import com.badlogic.gdx.graphics.g3d.Model;

///////////////////////////////////////////////////////////////////////////////////////////////////
/* Created by Eric on 9/3/2015.
*
* Class: Enemy
*
* NOTES: Base class for enemies should path/target enemies and accept incoming damage
*
*   Enemies should target the base or player.
*   Should have way to select targets and move towards them
*
*//////////////////////////////////////////////////////////////////////////////////////////////////
public class Enemy extends BoxObject
{
    private AssetManager assets;

    public Enemy(int hp, int dmg, float spd)
    {
        super(hp, dmg, spd, true);
        assets = new AssetManager();

    }

    protected void addAssets(String path)
    {
        if (!assets.getAssetNames().contains(path, false))
            assets.load(path, Model.class);
    }

    protected boolean waitLoad()
    {
        return assets.update();
    }

    protected Model loadModel(String path)
    {
        return assets.get(path);
    }
}
