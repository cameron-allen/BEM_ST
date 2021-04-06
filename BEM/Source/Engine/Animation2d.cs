using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BEM.Source.Engine
{
    public class Animation2d     //class from https://www.youtube.com/watch?v=orQO9O1ikkw
    {
        public Rectangle rectangle;

        Color color;

        Vector2 origin;
        public Vector2 velocity;
        public Vector2 dims;
        public Vector2 pos;
        public Texture2D texture;
        Texture2D idleTexture;
        public string walk;
        public bool isPunching;
        public Vector2 offset;

        public int currFrame; 
        int sheetSize; //will use to set how many sprites are on the sheet
        float timer;
        public int instance;
        public float interval; //interval between frames
 
        public float prevLocX;
        public float prevLocY;

        public Animation2d(string WALK, string I, Vector2 POS, Vector2 DIMS, int SHEETSIZE) //constructor
        {
            interval = 75;
            walk = WALK;
            if (WALK != null)
            {
                texture = Globals.content.Load<Texture2D>(WALK);
            }
            //texture = Globals.content.Load<Texture2D>(WALK);

            if (I != null)
            {
                idleTexture = Globals.content.Load<Texture2D>(I);
            }
            pos = POS;
            dims = DIMS;
            instance = 1;
            prevLocX = 0;
            sheetSize = SHEETSIZE;
            color = Color.White;
        }
        public void setInterval(int INTERVAL)
        {
            interval = INTERVAL;
        }
        public virtual void Update(GameTime gameTime, List<Animation2d> entities) //updates animation
        {
            rectangle = new Rectangle(currFrame * (int)dims.X, 0, (int)dims.X, (int)dims.Y);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (!(sheetSize == 1) && texture != null)
            {

                if (prevLocX < pos.X)
                {
                    instance = 1;
                    AnimateRight(gameTime);

                }
                else if (prevLocX > pos.X)
                {
                    instance = 2;
                    AnimateLeft(gameTime);


                }
                else if (prevLocY != pos.Y && prevLocX == pos.X || isPunching) 
                { 
                    if (instance == 1)
                    {
                        AnimateRight(gameTime);
                    }else if (instance == 2)
                    {
                        AnimateLeft(gameTime);
                    }
                }
                else
                {
                    if (idleTexture != null)
                    {
                        AnimateIdle(gameTime);
                    }
                    else
                    {
                        if (instance == 1)
                        {
                            currFrame = 0;
                        }
                        else
                        {
                            currFrame = sheetSize / 2;
                        }
                    }

                }
                prevLocY = pos.Y;
                prevLocX = pos.X;

            }else if (!(sheetSize == 1) && idleTexture != null)
            {
                AnimateIdle(gameTime);
            }

            if (entities != null)       //checks if Animation2ds are touching
            {
                foreach (var Animation2d in entities)
                {
                    
                    if (Animation2d == this)
                        continue;

                    this.color = Color.White;
          

                    if (this.pos.X <= Animation2d.pos.X + Animation2d.dims.X &&
                        this.pos.X + this.dims.X >= Animation2d.pos.X &&
                        this.pos.Y <= Animation2d.pos.Y + Animation2d.dims.Y/4 &&
                        this.pos.Y + this.dims.Y/4 >= Animation2d.pos.Y)
                    {
                        this.color = Color.Red;
                    }
                }
            }
           
        }

        public void AnimateRight(GameTime gameTime) //goes through animation for going right
        {
                     
            if (timer >= interval)
            {
                currFrame++;
                timer = 0;
                if (currFrame >= sheetSize / 2)
                {
                    currFrame = 0;
                }
            }
        }

        public void AnimateIdle(GameTime gameTime) //goes through animation for going left
        {
            if (timer >= interval)
            {
                currFrame++;
                timer = 0;
                if (currFrame >= sheetSize)
                {
                    currFrame = 0;
                }
            }
        }

        public void AnimateLeft(GameTime gameTime) //goes through animation for going left
        {
            if (timer > interval)
            {
                currFrame++;
                timer = 0;
                if (currFrame >= sheetSize || currFrame < sheetSize/2)
                {
                    currFrame = sheetSize / 2;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) //draws sprite
        {
            if (texture != null)
            {
                spriteBatch.Draw(texture, pos + offset, rectangle, color, 0f, origin, 1.0f, SpriteEffects.None, 0);
            }
                
            else
            {
                spriteBatch.Draw(idleTexture, pos + offset, rectangle, color, 0f, origin, 1.0f, SpriteEffects.None, 0);
            }
        }
    }

}
