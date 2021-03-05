using System;
using System.Collections.Generic;
using System.Text;
using BEM.Source.GamePlay.World;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using BEM.Source.Engine.Camera;

namespace BEM.Source.Engine
{
    public class World
    {
        public Vector2 offset;  //main character offset
        MainChar m_char;        //main character
        Basic2d reference;      //temp picture for movement reference
        public Vector2 enOff;

        public World()
        {
            reference = new Basic2d("2d\\images", new Vector2(200, 200), new Vector2(128, 128));
            //file location, screen loc, dims
            m_char = new MainChar("2d\\nerd", new Vector2(300, 300), new Vector2(128, 128));

            offset = new Vector2(0, 0);
            enOff = new Vector2(0, 0);
            Globals._camera = new Camera2d();
            //Globals._camera.Transform.
        }

        public virtual void Update()
        {
            m_char.Update(offset);
            reference.Update(new Vector2(0, 0));
            Globals._camera.Pan(m_char.pos, m_char.dims);
        }

        public virtual void Draw()
        {
            int xDirect = Math.Sign(m_char.pos.X);
            int yDirect = Math.Sign(m_char.pos.Y);
            //enOff = new Vector2(m_char.pos.X, m_char.pos.Y);
            reference.Draw(enOff);
            m_char.Draw(offset);
        }
    }
}
