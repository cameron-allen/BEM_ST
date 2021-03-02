using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEM.Source.Engine.Camera
{
    public class Camera2d
    {
        public Matrix Transform { get; private set; }

        public void Follow(Vector2 POS, Vector2 DIMS)
        {
            var position = Transform = Matrix.CreateTranslation(-POS.X - (DIMS.X / 2), -POS.Y - (DIMS.Y / 2), 0); 
            
            var offset = Matrix.CreateTranslation(Globals.screenWidth/2, Globals.screenHeight/2, 0);

            Transform = position * offset;

        }

        public void Pan(bool canMove, Vector2 POS, int offScrnSide, float desPos)
        {
            if (!canMove)
            {
                float direction = 0;
                if (offScrnSide == 1)
                {
                    direction = -4;
                }else if (offScrnSide == 2)
                {
                    direction = 4;
                }
                POS = new Vector2(POS.X + direction, POS.Y);
                if (POS.X == desPos)
                {
                    canMove = true;
                    offScrnSide = 0;
                }
            }
        }


    }
}
