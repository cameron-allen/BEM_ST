using System;
using System.Collections.Generic;
using System.Text;
using BEM.Source.GamePlay.World;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using BEM.Source.Engine.Camera;
using Microsoft.Xna.Framework.Graphics;
using BEM.Source.Engine.Background;

namespace BEM.Source.Engine
{
    public class World
    {
        Player player;

        private List<Animation2d> entities; //holds entities (Animation2d objects) that will collide



        public World()
        {
            //file location, screen loc, dims
            player = new Player("bin/Windows/Content/nerd_move", null, new Vector2(300, 300), new Vector2(56, 96), Vector2.Zero, 8); //main character //56, 96
            entities = new List<Animation2d>()
            {
                new Animation2d("bin/Windows/Content/zamble", null, new Vector2(400, 150), new Vector2(96, 128), Vector2.Zero, 1, 3) {}, //test collision object
            };
            
            Globals._camera = new Camera2d();
            //Globals._camera.Transform.
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var Animation2d in entities)
            {
                Animation2d.Update(gameTime, entities);
            }
            player.Update(gameTime, entities);
           
            Globals._camera.Pan(player.pos, player.dims);
        }

        public virtual void Draw()
        {
            
            foreach (var Animation2d in entities)
            {
                Animation2d.Draw(Globals._spriteBatch);
            }
            player.Draw(Globals._spriteBatch);
        }
    }
}
