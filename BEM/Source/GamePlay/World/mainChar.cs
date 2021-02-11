using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEM.Source.GamePlay.World
{
    class MainChar : Basic2d
    {
        float sprint = 1;
        int instance = 0;

        public MainChar(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
        }

        public override void Update()
        {
            if (Globals.keyboard.GetPress("Space"))
            {
                sprint = (float) 2.5;
            }else
            {
                sprint = 1;
            }


            if (Globals.keyboard.GetPress("A"))
            {
                if (instance != 1)
                {
                    ChangePath("2D\\nerd_flip");
                    instance = 0;
                }
                pos = new Vector2(pos.X - 2 * sprint, pos.Y);
            }
            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + 2 * sprint);
            }
            if (Globals.keyboard.GetPress("D"))
            {
                if (instance != 0)
                {
                    ChangePath("2d\\nerd");
                    instance = 1;
                }

                pos = new Vector2(pos.X + 2 * sprint, pos.Y);
            }
            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - 2 * sprint);
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
