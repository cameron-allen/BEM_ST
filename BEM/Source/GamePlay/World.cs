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
        Animation2d test;
        public Vector2 enOff;
        //Animation2d torch;


        public World()
        {
            //file location, screen loc, dims
            m_char = new MainChar("bin/Windows/Content/nerd_move", null, new Vector2(300, 300), new Vector2(64, 96), 8); //initailizes main character sprite and location
            char_hitbox = new MainChar("bin/Windows/Content/char_hitbox", null, new Vector2(300, 300), new Vector2(64, 96), 1);
            test = new Animation2d("bin/Windows/Content/Wall/torch", null, new Vector2(300, 300), new Vector2(128, 128), 1);
            offset = new Vector2(0, 0);
            enOff = new Vector2(0, 0);
            Globals._camera = new Camera2d();
            //Globals._camera.Transform.
        }

        public virtual void Update(GameTime gameTime)
        {
            m_char.Update(gameTime);
            char_hitbox.Update(gameTime);
            test.Update(gameTime);
            //torch.Update(Globals.time);
            Globals._camera.Pan(m_char.pos, m_char.dims);
        }

        public virtual void Draw()
        {
            //torch.Draw(Globals._spriteBatch);
            test.Draw(Globals._spriteBatch);
            m_char.Draw(Globals._spriteBatch);
            char_hitbox.Draw(Globals._spriteBatch);
        }
    }
}
