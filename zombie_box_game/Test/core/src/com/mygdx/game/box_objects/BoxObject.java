package com.mygdx.game.box_objects;
import com.badlogic.gdx.assets.AssetManager;
import com.badlogic.gdx.graphics.Camera;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.g3d.utils.*;
import com.badlogic.gdx.graphics.g3d.*;
import com.badlogic.gdx.math.Vector3;
import com.sun.org.apache.xpath.internal.operations.Mod;

///////////////////////////////////////////////////////////////////////////////////////////////////
/* Created by Eric on 9/3/2015.
*
* Class: BoxObject
*
* NOTES: Base class for box objects holds Image, Sound, and location data
*
*
*//////////////////////////////////////////////////////////////////////////////////////////////////
public class BoxObject
{
    private ModelInstance modelInstance;
    private Vector3 location;
    private int health = 0;
    private int damage = 0;
    private float speed = 0f;
    private boolean evil = false;
    public BoxObject(int hp, int dmg, float spd,boolean ev)
    {
        health = hp;
        damage = dmg;
        speed = spd;
        evil = ev;

    }

    public void setModelInstance(Model model,Vector3 pos, Vector3 axis, float angle)
    {
        location = pos;
        modelInstance= new ModelInstance(model);
        modelInstance.transform.translate(pos);
        modelInstance.transform.rotate(axis,angle);
    }

    public ModelInstance render(){return modelInstance;}

    public void move(Vector3 pos)
    {
        modelInstance.transform.setToLookAt(location,pos, new Vector3(1,0,1));
    }

}
