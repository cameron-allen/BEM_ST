using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace BEM.Source.Engine
{
    public class World
    {
        Basic2d mainChar;

        public World()
        {                        //file location, screen loc, dims
            mainChar = new Basic2d("2d\\images", new Vector2(300, 300), new Vector2(48, 48));
        }

        public virtual void Update()
        {
            mainChar.Update();
        }

        public virtual void Draw()
        {
            mainChar.Draw();
        }
    }
}
