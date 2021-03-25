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
        MainChar m_char;        //main character
        MainChar char_hitbox;
        //Animation2d test;
        public Vector2 enOff;

        private List<Animation2d> entities;
        //Animation2d torch;


        public World()
        {
            //file location, screen loc, dims
            entities = new List<Animation2d>()
            {
                new MainChar("bin/Windows/Content/nerd_move", null, new Vector2(300, 300), new Vector2(64, 96), 8) {},
                new Animation2d("bin/Windows/Content/images", null, new Vector2(900, 300), new Vector2(256, 256), 1) {}

            //initailizes main character sprite and location
            };
            m_char = new MainChar("bin/Windows/Content/nerd_move", null, new Vector2(300, 300), new Vector2(64, 96), 8); //initailizes main character sprite and location
            char_hitbox = new MainChar("bin/Windows/Content/char_hitbox", null, new Vector2(300, 300), new Vector2(64, 96), 1);
            //test = new Animation2d("bin/Windows/Content/images", null, new Vector2(900, 300), new Vector2(256, 256), 1);
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

            m_char.Update(gameTime, null);
            char_hitbox.Update(gameTime, null);
            //test.Update(gameTime, entities);
            //torch.Update(Globals.time);
            Globals._camera.Pan(m_char.pos, m_char.dims);
        }

        public virtual void Draw()
        {
            //torch.Draw(Globals._spriteBatch);
            //test.Draw(Globals._spriteBatch);
            foreach (var Animation2d in entities)
            {
                Animation2d.Draw(Globals._spriteBatch);
            }
            //m_char.Draw(Globals._spriteBatch);
            char_hitbox.Draw(Globals._spriteBatch);
        }
    }
}
