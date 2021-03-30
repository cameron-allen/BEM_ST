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
        public Vector2 offset;  //main character offset
        MainChar char_hitbox;
 
        public Vector2 enOff;

        private List<Animation2d> entities; //holds entities (Animation2d objects) that will collide



        public World()
        {
            //file location, screen loc, dims
            entities = new List<Animation2d>()
            {
                new Animation2d("bin/Windows/Content/nerd_move", null, new Vector2(400, 150), new Vector2(64, 96), 1) {}, //test collision object
                new MainChar("bin/Windows/Content/nerd_move", null, new Vector2(300, 300), new Vector2(64, 96), 8) {} //main character
            };
            char_hitbox = new MainChar("bin/Windows/Content/char_hitbox", null, new Vector2(300, 300), new Vector2(64, 96), 1);
            offset = new Vector2(0, 0);
            enOff = new Vector2(0, 0);
            Globals._camera = new Camera2d();
            //Globals._camera.Transform.
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var Animation2d in entities)
            {
                Animation2d.Update(gameTime, entities);
            }

            char_hitbox.Update(gameTime, null);
            Globals._camera.Pan(char_hitbox.pos, char_hitbox.dims);
        }

        public virtual void Draw()
        {
            
            foreach (var Animation2d in entities)
            {
                Animation2d.Draw(Globals._spriteBatch);
            }

            //char_hitbox.Draw(Globals._spriteBatch);
        }
    }
}
