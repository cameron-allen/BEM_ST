using System;
using System.Collections.Generic;
using System.Text;
using BEM.Source.GamePlay.World;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using BEM.Source.Engine.Camera;
using Microsoft.Xna.Framework.Graphics;
using BEM.Source.Engine.Background;
using System.Diagnostics;

namespace BEM.Source.Engine
{
    
    public class World
    {
        Player player;
        private List<Animation2d> players = new List<Animation2d>();
        private List<Animation2d> enemies; //holds enemies (Animation2d objects) that will collide



        public World()
        {
            //file location, screen loc, dims
            int distance = 460;
            enemies = new List<Animation2d>()
            {
                new Enemy("bin/Windows/Content/zamble", null, new Vector2(distance, 150), new Vector2(96, 128), Vector2.Zero, 16, 3) {}, //test collision object
                new Enemy("bin/Windows/Content/zamble", null, new Vector2(distance + Globals.screenWidth, 150), new Vector2(96, 128), Vector2.Zero, 16, 3) {}, //test collision object
                new Enemy("bin/Windows/Content/zamble", null, new Vector2(distance + Globals.screenWidth, 300), new Vector2(96, 128), Vector2.Zero, 16, 3) {}, //test collision object
                new Enemy("bin/Windows/Content/zamble", null, new Vector2(distance + Globals.screenWidth * 2, 150), new Vector2(96, 128), Vector2.Zero, 16, 3) {}, //test collision object
                new Enemy("bin/Windows/Content/zamble", null, new Vector2(distance + Globals.screenWidth * 2, 300), new Vector2(96, 128), Vector2.Zero, 16, 3) {}, //test collision object
                new Enemy("bin/Windows/Content/zamble", null, new Vector2(distance + 60 + Globals.screenWidth * 2, 225), new Vector2(96, 128), Vector2.Zero, 16, 3) {}, //test collision object
            };

            player = new Player("bin/Windows/Content/nerd_move", null, new Vector2(100, 200), new Vector2(56, 96), Vector2.Zero, 8, 3); //main character //56, 96

            enemies.Add(player);
            
            Globals._camera = new Camera2d();
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var Animation2d in enemies)
            {
                Animation2d.Update(gameTime, enemies);
            }

            foreach (var Animation2d in players)
            {
                Animation2d.Update(gameTime, enemies);
            }
           
            Globals._camera.Pan(player.pos, player.dims);
        }

        public virtual void Draw()
        {

            
            foreach (var Animation2d in enemies)
            {
                if (Animation2d.pos.Y +10 <= Player.playerPos.Y && !Animation2d.isPlayer)
                {
                    Animation2d.Draw(Globals._spriteBatch);
                  
                }
            }

            foreach (var Animation2d in enemies)
            {
                if (Animation2d.isPlayer)
                {
                    Animation2d.Draw(Globals._spriteBatch);
                }
            }
            
            foreach (var Animation2d in enemies)
            {
                if (!Animation2d.isPlayer)
                {
                    if (Animation2d.pos.Y + 10 > Player.playerPos.Y)
                    {
                        Animation2d.Draw(Globals._spriteBatch);
                    }
                }
            }
        }
    }
}
