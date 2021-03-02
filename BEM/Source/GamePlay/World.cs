using System;
using System.Collections.Generic;
using System.Text;
using BEM.Source.GamePlay.World;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using BEM.Source.Engine.Camera;

namespace BEM.Source.Engine
{
    public class World
    {
        public Vector2 offset;
        MainChar m_char;

        public World()
        {                        //file location, screen loc, dims
            m_char = new MainChar("2d\\nerd", new Vector2(300, 300), new Vector2(128, 128));
            offset = new Vector2(0, 0);
        }

        public virtual void Update()
        {
            m_char.Update(offset);
            //Globals._camera.Follow(m_char.pos, m_char.dims);
        }

        public virtual void Draw()
        {
            m_char.Draw(offset);
        }
    }
}
