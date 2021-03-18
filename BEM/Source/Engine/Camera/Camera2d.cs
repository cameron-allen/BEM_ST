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
        int curPos;
        int nextScreen = Globals.screenWidth;
        public static int screenNum;

        public Camera2d()
        {
            curPos = 0;
            screenNum = 1;
            nextScreen = Globals.screenWidth;
        }

        public void Follow(Vector2 POS, Vector2 DIMS)       //camera follows the player 
        {
            var position = Transform = Matrix.CreateTranslation(-POS.X - ((DIMS.X / 4) / 2f), -POS.Y - ((DIMS.Y / 4) / 2f), 0);     //sets translation to center of sprite (the + 55 and -50 word hard coded to adjust for error)
            
            var offset = Matrix.CreateTranslation(Globals.screenWidth/2, Globals.screenHeight/2, 0);    //pushes sprite to the center of the screen

            Transform = position * offset; //translates center of sprite to be exactly in the center of the secreen

        }
        //block end
        public void Pan(Vector2 POS, Vector2 DIMS)   //Pans screen
        {
            
            Transform = Matrix.CreateTranslation(curPos, 0, 0); ;
            
            var position = Transform;

            if (POS.X < nextScreen - Globals.screenWidth)
            {
                curPos += Globals.screenWidth;
                nextScreen -= Globals.screenWidth;
                --screenNum;
            }
            
            if (POS.X > nextScreen)
            {
                curPos -= Globals.screenWidth;
                nextScreen += Globals.screenWidth;
                ++screenNum;
            }
            Transform = position;

        }


    }
}
