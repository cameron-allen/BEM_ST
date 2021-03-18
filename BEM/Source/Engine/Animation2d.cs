using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEM.Source.Engine
{
    public class Animation2d     //class from https://www.youtube.com/watch?v=orQO9O1ikkw
    {
        Rectangle rectangle;
        Vector2 origin;
        Vector2 dims;
        Vector2 pos;
        Texture2D texture;

        bool idle;
        int currFrame; 
        int sheetSize; //will use to set how many sprites are on the sheet
        float timer;
        float interval = 75; //interval between frames

        public Animation2d(Texture2D TEXTURE, Vector2 POS, Vector2 DIMS, int SHEETSIZE, bool IDLE)
        {
            texture = TEXTURE;
            pos = POS;
            dims = DIMS;

            sheetSize = SHEETSIZE;
            idle = IDLE;
        }

        public void Update(GameTime gameTime) //updates animation
        {
            rectangle = new Rectangle(currFrame * (int)dims.X, 0, (int)dims.X, (int)dims.Y);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
            //pos = pos + velocity;

            if (idle)
            {
                AnimateIdle(gameTime);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                AnimateRight(gameTime);
                //velocity.X = 3;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                AnimateLeft(gameTime);
                //velocity.X = -3;
            }
            else
            {
                
            }
        }

        public void AnimateRight(GameTime gameTime) //goes through animation for going right
        {
           
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            
            if (timer >= interval)
            {
                currFrame++;
                timer = 0;
                if (currFrame > sheetSize/2)
                {
                    currFrame = 0;
                }
            }
        }

        public void AnimateIdle(GameTime gameTime) //goes through animation for going left
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            //currFrame++;
            if (timer >= interval)
            {
                currFrame++;
                timer = 0;
                if (currFrame > sheetSize)
                {
                    currFrame = 0;
                }
            }
        }

        public void AnimateLeft(GameTime gameTime) //goes through animation for going left
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;
            if (timer > interval)
            {
                currFrame++;
                timer = 0;
                if (currFrame > sheetSize || currFrame < sheetSize/2)
                {
                    currFrame = 4;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) //draws sprite
        {
            spriteBatch.Draw(texture, pos, rectangle, Color.White, 0f, origin, 1.0f, SpriteEffects.None, 0);
        } 
    }
}
