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

        private void updMove()
        {
            if (Globals.keyState.IsKeyDown(Keys.LeftShift))
            {
               
                sprint = (float)2.5;
            }
            else
            {
                sprint = 1;
            }

            if (Globals.keyState.IsKeyDown(Keys.A))
            {
                if (instance == 0)
                {

                    ChangePath("2d\\nerd_flip");
                    instance = 1;
                }

                pos = new Vector2(pos.X - 2 * sprint, pos.Y);
            }
            if (Globals.keyState.IsKeyDown(Keys.S))
            {
                pos = new Vector2(pos.X, pos.Y + 2 * sprint);
            }
            if (Globals.keyState.IsKeyDown(Keys.D))
            {
                if (instance == 1)
                {
                    ChangePath("2d\\nerd");
                    instance = 0;
                }

                pos = new Vector2(pos.X + 2 * sprint, pos.Y);
            }
            if (Globals.keyState.IsKeyDown(Keys.W))
            {
                pos = new Vector2(pos.X, pos.Y - 2 * sprint);
            }

        }

        public override void Update()
        {

            updMove();
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
