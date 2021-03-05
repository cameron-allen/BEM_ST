using BEM.Source.Engine;
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
        }

        protected override void LoadContent() 
        {
            Globals.content = this.Content;
            Globals._spriteBatch = new SpriteBatch(GraphicsDevice);

            

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

            world.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            Globals._spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: Globals._camera.Transform); //transformMatrix: Globals._camera.Transform    SpriteSortMode.Deferred, BlendState.AlphaBlend

            world.Draw();

            Globals._spriteBatch.End();

            base.Draw(gameTime);
        }
    }


}
