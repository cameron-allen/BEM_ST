﻿using BEM.Source.Engine;
using BEM.Source.Engine.Background;
using BEM.Source.Engine.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel;


namespace BEM
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private World world;

        private Align_Basic2d wall;
        private Align_Basic2d floor;
        public Align_Basic2d torch;
        public Align_Basic2d torch_light;
        Animation2d torch_an;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
        
            Globals.screenWidth = 640;
            Globals.screenHeight = 360;
            _graphics.PreferredBackBufferWidth = Globals.screenWidth;       //sets screen to 640 by 360 pixels
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()  //initialize settings ex: resolution
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            torch_an = new Animation2d(Globals.content.Load<Texture2D>("bin/Windows/Content/Wall/torch_idle"), new Vector2(400, 200), new Vector2(128, 128), 3, true);

        }

        protected override void LoadContent() 
        {
            Globals.content = this.Content;
            Globals._spriteBatch = new SpriteBatch(GraphicsDevice);

            wall = new Align_Basic2d("bin/Windows/Content/Wall/rock_back", new Vector2(0, 130), new Vector2(64, 64), new Vector2(11, 3));
            torch = new Align_Basic2d("bin/Windows/Content/Wall/torch", new Vector2(107, 50), new Vector2(128, 128), new Vector2(3, 1));
            torch_light = new Align_Basic2d("bin/Windows/Content/Wall/torch_light", new Vector2(107, 50), new Vector2(128, 128), new Vector2(3, 1));
            floor = new Align_Basic2d("bin/Windows/Content/Floor/large_tile_floor", new Vector2(0, 386), new Vector2(64, 64), new Vector2(11, 4));




            // TODO: use this.Content to load your game content here

            world = new World();
        }

        protected override void UnloadContent() 
        {
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime) //update all game logic
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (Keyboard.GetState().IsKeyDown(Keys.F4))     //allows to toggle fullscreen with F4
                _graphics.ToggleFullScreen();


            // TODO: Add your update logic here
            Globals.keyState = Keyboard.GetState();

            wall.Update(Vector2.Zero);

            if (Camera2d.screenNum == 2) //if on the 2nd screen
            {
                floor.ChangePath("bin/Windows/Content/Floor/floor");
            } else if (Camera2d.screenNum == 3) //if on the 3rd screen
            {
                floor.ChangePath("bin/Windows/Content/Floor/cracked_floor");
            } else //if on any other screen
            {
                floor.ChangePath("bin/Windows/Content/Floor/large_tile_floor");
            }
            torch_an.Update(Globals.time);

            floor.Update(Vector2.Zero);
            
            torch_light.Update(new Vector2(85, 0));
            torch.Update(new Vector2(85, 0));

            world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Teal);

            Globals._spriteBatch.Begin();
            wall.Draw();
            floor.Draw();
            torch.Draw();
            torch_light.Draw();
            Globals._spriteBatch.End();

            // TODO: Add your drawing code here
            Globals._spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: Globals._camera.Transform); //transformMatrix: Globals._camera.Transform    SpriteSortMode.Deferred, BlendState.AlphaBlend

            torch_an.Draw(Globals._spriteBatch);
            world.Draw();


            Globals._spriteBatch.End();

           

            base.Draw(gameTime);
        }
    }


}
