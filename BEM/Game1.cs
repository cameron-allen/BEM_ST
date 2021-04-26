using BEM.Source;
using BEM.Source.Engine;
using BEM.Source.Engine.Background;
using BEM.Source.Engine.Camera;
using BEM.Source.GamePlay.World;
using BEM.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace BEM
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private State _currentState;
        private State _nextState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Globals.screenWidth = 640;
            Globals.screenHeight = 360;
            _graphics.PreferredBackBufferWidth = Globals.screenWidth;       //sets screen to 640 by 360 pixels
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;
            _graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()  //initialize settings ex: resolution
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
            
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void LoadContent() 
        {
            Globals.content = this.Content;
            _currentState = new MenuState(this, _graphics.GraphicsDevice);
            Globals._spriteBatch = new SpriteBatch(GraphicsDevice);
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

            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Teal);
            _currentState.Draw(gameTime, Globals._spriteBatch);

            base.Draw(gameTime);
        }
    }


}
