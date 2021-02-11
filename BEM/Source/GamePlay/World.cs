using System;
using System.Collections.Generic;
using System.Text;
using BEM.Source.GamePlay.World;
using Microsoft.Xna.Framework;

namespace BEM.Source.Engine
{
    public class World
    {
        MainChar m_char;

        public World()
        {                        //file location, screen loc, dims
            m_char = new MainChar("2d\\nerd", new Vector2(300, 300), new Vector2(128, 128));
        }

        public virtual void Update()
        {
            m_char.Update();
        }

        public virtual void Draw()
        {
            m_char.Draw();
        }
    }
}
