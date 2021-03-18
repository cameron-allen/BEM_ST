using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEM.Source.Engine.Background
{
    public class Align_Basic2d //this class copies a texture and draws it across a designated space
    {
        private Vector2 lengths;
        Vector2 pos;
        Vector2 dims;
        private string path;
 
        Basic2d[] _backgroundX; //array of textures drawn across x axis
        List<Basic2d[]> _backgroundYList = new List<Basic2d[]>(); //array of arrays of textures (this is used to have an multiple arrays of textures 
                                                                  //above _backgroundX in order to make a rectangel shape)
        public Align_Basic2d(string PATH, Vector2 POS, Vector2 DIMS, Vector2 LENGTHS)
        {
            pos = POS;
            dims = DIMS;
            path = PATH;
            lengths = LENGTHS;

            _backgroundX = new Basic2d[(int)lengths.X];

            if (lengths.Y >= 2)
            {
                for (int n = 0; n < (int)lengths.Y - 1; n++)
                {

                    Basic2d[] _backgroundY = new Basic2d[(int)lengths.X];
                    _backgroundYList.Add(_backgroundY);

                }
            }
        }
        public void ChangePath(string PATH) //changes the path of the texture so that a different sprite can be used
        {
            path = PATH;

        }
        public string getPath()
        {
            return this.path;
        }
        
        public void Update(Vector2 offset) //updates the textures
        {
            
            int increment = 0;
            if ((lengths.X != 0)) 
            {
                for (int i = 0; i < (int)lengths.X; i++)
                {
                    _backgroundX[i] = new Basic2d(this.path, new Vector2(pos.X + increment, pos.Y), dims);
                    increment += (int)dims.X + (int)offset.X;
                }
            }
            
            int increment2 = (int)dims.Y;
            if (lengths.Y >= 2) //this if statement ensures that if the y length doesn't have a value of 2, no textures will be copied above _backgroundX
            {
                for (int n = 0; n < (int)lengths.Y - 1; n++)
                {
                    increment = 0;

                    for (int i = 0; i < (int)lengths.X; i++)
                    {
                        _backgroundYList[n][i] = new Basic2d(this.path, new Vector2(pos.X + increment, pos.Y - increment2), dims);
                        increment += (int)dims.X + (int)offset.X;
                    }
                    increment2 += (int)dims.Y;
                }
            }
        }

        public void Draw() //draws the textures
        {
            if ((lengths.X != 0))
            {
                for (int i = 0; i < (int)lengths.X; i++)
                {
                    _backgroundX[i].Draw(Vector2.Zero);
                }
            }

            if (lengths.Y >= 2)
            {
                for (int n = 0; n < (int)lengths.Y - 1; n++)
                {
                    for (int i = 0; i < (int)lengths.X; i++)
                    {
                        _backgroundYList[n][i].Draw(Vector2.Zero);
                    }

                }
            }
        }
    }
}
