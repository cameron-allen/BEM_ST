using BEM.Source;
using BEM.Source.Engine;
using BEM.Source.Engine.Background;
using BEM.Source.Engine.Camera;
using BEM.Source.GamePlay.World;
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
        private float timerEnd = 0f;
        private SpriteFont font;
        private bool reachEnd = false;

        Animation2d torch01;
        Animation2d torch02;
        Animation2d torch03;

        Animation2d heart1;
        Animation2d heart2;
        Animation2d heart3;
        Animation2d heart4;
        Animation2d heart5;

        public Align_Basic2d torch_light;

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

            font = Globals.content.Load<SpriteFont>("bin\\Windows\\Content\\Fonts\\Font");

            wall = new Align_Basic2d("bin/Windows/Content/Wall/rock_back", new Vector2(0, 130), new Vector2(64, 64), new Vector2(11, 3));
           
            torch01 = new Animation2d(null, "bin/Windows/Content/Wall/torch_idle", new Vector2(107, 50), new Vector2(128, 128), Vector2.Zero, 3, 0);
            torch01.setInterval(150);
            torch02 = new Animation2d(null, "bin/Windows/Content/Wall/torch_idle", new Vector2(320, 50), new Vector2(128, 128), Vector2.Zero, 3, 0);
            torch02.setInterval(150);
            torch03 = new Animation2d(null, "bin/Windows/Content/Wall/torch_idle", new Vector2(534, 50), new Vector2(128, 128), Vector2.Zero, 3, 0);
            torch03.setInterval(150);

            heart1 = new Animation2d(null, "bin/Windows/Content/beating_heart", new Vector2(15, 20), new Vector2(21, 21), Vector2.Zero, 7, 0);
            heart1.setInterval(100);
            heart2 = new Animation2d(null, "bin/Windows/Content/beating_heart", new Vector2(15, 45), new Vector2(21, 21), Vector2.Zero, 7, 0);
            heart2.setInterval(100);
            heart3 = new Animation2d(null, "bin/Windows/Content/beating_heart", new Vector2(15, 70), new Vector2(21, 21), Vector2.Zero, 7, 0);
            heart3.setInterval(100);
            heart4 = new Animation2d(null, "bin/Windows/Content/beating_heart", new Vector2(15, 95), new Vector2(21, 21), Vector2.Zero, 7, 0);
            heart4.setInterval(100);
            heart5 = new Animation2d(null, "bin/Windows/Content/beating_heart", new Vector2(15, 120), new Vector2(21, 21), Vector2.Zero, 7, 0);
            heart5.setInterval(100);

            //torch = new Align_Animation2d(t, new Vector2(107, 50), new Vector2(128, 128), new Vector2(3, 1), );
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
            
            floor.Update(Vector2.Zero);
            
            torch_light.Update(new Vector2(85, 0));

            torch01.Update(gameTime, null);
            torch02.Update(gameTime, null);
            torch03.Update(gameTime, null);

            heart1.Update(gameTime, null);
            heart2.Update(gameTime, null);
            heart3.Update(gameTime, null);
            heart4.Update(gameTime, null);
            heart5.Update(gameTime, null);

            world.Update(gameTime);

            if (Camera2d.screenNum == 4 || reachEnd || !Player.alive)
            {
                reachEnd = true;
                timerEnd += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            if (timerEnd > 2600)
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Teal);

            Globals._spriteBatch.Begin();
            wall.Draw();
            floor.Draw();
            torch01.Draw(Globals._spriteBatch);
            torch02.Draw(Globals._spriteBatch);
            torch03.Draw(Globals._spriteBatch);

            Globals._spriteBatch.End();

            // TODO: Add your drawing code here
            Globals._spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: Globals._camera.Transform); //transformMatrix: Globals._camera.Transform    SpriteSortMode.Deferred, BlendState.AlphaBlend

            world.Draw();

            Globals._spriteBatch.End();

            Globals._spriteBatch.Begin();
            if (Player.alive)
            {
                heart1.Draw(Globals._spriteBatch);
            }
            if (Player.hPoints >= 2)
            {
                heart2.Draw(Globals._spriteBatch);
            }
            if (Player.hPoints >= 3)
            {
                heart3.Draw(Globals._spriteBatch);
            }
            if (Player.hPoints >= 4)
            {
                heart4.Draw(Globals._spriteBatch);
            }
            if (Player.hPoints >= 5)
            {
                heart5.Draw(Globals._spriteBatch);
            }

            torch_light.Draw();

            if (timerEnd > 0 && Camera2d.screenNum == 4)
            {
                Globals._spriteBatch.DrawString(font, "You Win!!", new Vector2(200, 80), Color.DarkSeaGreen);
            }
            else if (timerEnd > 0 && !Player.alive)
            {
                Globals._spriteBatch.DrawString(font, "Game Over", new Vector2(200, 80), Color.Crimson);
            }

            Globals._spriteBatch.End();

           

            base.Draw(gameTime);
        }
    }


}
