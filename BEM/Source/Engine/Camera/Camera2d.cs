using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEM.Source.Engine.Camera
{
    public class Camera2d  
    {
        //block of code comes from https://www.youtube.com/watch?v=ceBCDKU_mNw
        public Nullable<Matrix> Transform { get; private set; }
        int initcPos = Globals.screenWidth + 20;
        int initnPos = (Globals.screenWidth + 20) + Globals.screenWidth;

        public void Follow(Vector2 POS, Vector2 DIMS)       //camera follows the player 
        {
            var position = Transform = Matrix.CreateTranslation(-POS.X + 55 - (DIMS.X / 2), -POS.Y + 50 - (DIMS.Y / 2), 0);     //sets translation to center of sprite (the + 55 and -50 word hard coded to adjust for error)
            
            var offset = Matrix.CreateTranslation(Globals.screenWidth/2, Globals.screenHeight/2, 0);    //pushes sprite to the center of the screen

            Transform = position * offset; //translates center of sprite to be exactly in the center of the secreen

        }
        //block end
        public void Pan(Vector2 POS, Vector2 DIMS)   //Work in Progress function of my own
        {
            int curPos = initcPos;
            int nPos = initnPos;
            
            if (POS.X < curPos)
            {
                Transform = null;
            }

            //Transform = null;
            var position = Transform;
            
            if (POS.X >= curPos && POS.X < 665)//&& POS.X >= 665)
            {
                
               
                position = Transform = Matrix.CreateTranslation(-POS.X - 64, -POS.Y + (Globals.screenHeight) - 64, 0);
                //var offset = Matrix.CreateTranslation(Globals.screenWidth / 2, Globals.screenHeight / 2, 0);    //pushes sprite to the center of the screen


                Transform = position;

            }
            
        }


    }
}
