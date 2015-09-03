package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g3d.attributes.ColorAttribute;
import com.badlogic.gdx.graphics.g3d.attributes.PointLightsAttribute;
import com.badlogic.gdx.graphics.g3d.utils.*;
import com.badlogic.gdx.graphics.g3d.*;
import com.badlogic.gdx.graphics.Color;
import	com.badlogic.gdx.graphics.VertexAttributes.Usage;
import com.badlogic.gdx.graphics.g3d.environment.*;



import com.badlogic.gdx.graphics.PerspectiveCamera;
import com.badlogic.gdx.math.Vector3;

import java.util.ArrayList;

import javax.swing.plaf.basic.BasicSplitPaneUI;
import javax.swing.text.Position;

public class MyGdxGame extends ApplicationAdapter {
	SpriteBatch batch;
	Texture img;
	public Model model;
	public PerspectiveCamera cam;
	public ArrayList<ModelInstance> instance;
	public Environment environment;
	public ModelBatch modelBatch;
	public FirstPersonCameraController camController;
	private int height = 20;
	public DirectionalLight light;

	@Override
	public void create () {
		modelBatch = new ModelBatch();
		//batch = new SpriteBatch();
		//img = new Texture("badlogic.jpg");

		Gdx.graphics.setTitle("Test Room");
		cam = new PerspectiveCamera(45, Gdx.graphics.getWidth(), Gdx.graphics.getHeight());

		cam.position.set(height, height, height);
		cam.lookAt(0,0,0);
		cam.far= 2000;
		cam.update();
		camController = new FirstPersonCameraController(cam);
		Gdx.input.setInputProcessor(camController);




		ModelBuilder modelBuilder = new ModelBuilder();
		instance = new ArrayList<ModelInstance>();

		model = modelBuilder.createBox(1000f, 0.1f, 1000f,
				new Material(ColorAttribute.createDiffuse(Color.GREEN)),
				Usage.Position | Usage.Normal);
		instance.add(new ModelInstance(model));

		model = modelBuilder.createBox(10f, 10f, 10f,
				new Material(ColorAttribute.createDiffuse(Color.RED)),
				Usage.Position | Usage.Normal);
		instance.add(new ModelInstance(model));

		model = modelBuilder.createBox(1000f, 1000f, 0.1f,
				new Material(ColorAttribute.createDiffuse(Color.WHITE)),
				Usage.Position | Usage.Normal);
		instance.add(new ModelInstance(model));

		model = modelBuilder.createBox(1000f, 1000f, 0.1f,
				new Material(ColorAttribute.createDiffuse(Color.WHITE)),
				Usage.Position | Usage.Normal);
		instance.add(new ModelInstance(model));

		model = modelBuilder.createBox(0.1f, 1000f, 1000f,
				new Material(ColorAttribute.createDiffuse(Color.WHITE)),
				Usage.Position | Usage.Normal);
		instance.add(new ModelInstance(model));

		model = modelBuilder.createBox(0.1f, 1000f, 1000f,
				new Material(ColorAttribute.createDiffuse(Color.WHITE)),
				Usage.Position | Usage.Normal);
		instance.add(new ModelInstance(model));


		instance.get(1).transform.translate(0, 5, 0);
		instance.get(2).transform.translate(0, 500, 500);
		instance.get(3).transform.translate(0,500,-500);
		instance.get(4).transform.translate(500,500,0);
		instance.get(5).transform.translate(-500,500,0);


		environment = new Environment();
		environment.set(new ColorAttribute(ColorAttribute.AmbientLight, 0.4f, 0.4f, 0.4f, 1f));
		light = new DirectionalLight();
				light.set(Color.WHITE, cam.direction);

		environment.add(light);
		light = new DirectionalLight();
		light.set(Color.WHITE, new Vector3(0, 0, 1).sub(cam.direction));

		environment.add(light);
		light = new DirectionalLight();
		light.set(Color.WHITE, new Vector3(1, 1, 0).sub(cam.direction));

		camController.setVelocity(20);
		camController.setDegreesPerPixel(1);
		environment.add(light);

	}

	@Override
	public void render ()
	{

		Gdx.gl.glViewport(0, 0, Gdx.graphics.getWidth(), Gdx.graphics.getHeight());
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT | GL20.GL_DEPTH_BUFFER_BIT);
		modelBatch.begin(cam);
		modelBatch.render(instance, environment);
		modelBatch.end();
		cam.position.y= 20;
		camController.update();

	}


}
