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
        public Vector2 enOff;
        //Animation2d torch;


        public World()
        {
            //file location, screen loc, dims
            m_char = new MainChar("bin/Windows/Content/nerd", new Vector2(300, 300), new Vector2(128, 128)); //initailizes main character sprite and location
            //torch = new Animation2d(Globals.content.Load<Texture2D>("bin/Windows/Content/Wall/torch_idle"), new Vector2(400, 400), new Vector2(128, 128), 3, false);

            offset = new Vector2(0, 0);
            enOff = new Vector2(0, 0);
            Globals._camera = new Camera2d();
            //Globals._camera.Transform.
        }

        public virtual void Update()
        {
            m_char.Update(offset);
            //torch.Update(Globals.time);
            Globals._camera.Pan(m_char.pos, m_char.dims);
        }

        public virtual void Draw()
        {
            //torch.Draw(Globals._spriteBatch);
            m_char.Draw(offset);
        }
    }
}
