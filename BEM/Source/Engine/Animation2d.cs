using BEM.Source.GamePlay.World;
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
    {                           //I worked on zombie sprite
        public Rectangle rectangle;

        public Color color;
        protected int health;
        public bool hasHealth;
        public bool isAlive;
        public float coolDown;
        public int adjustHitbox = 0;

        public Vector2 origin;
        public Vector2 dims;
        public Vector2 pos;
        public Texture2D texture;
        Texture2D idleTexture;
        public string walk;
        public bool isHitting;
        public Vector2 offset;
        public Vector2 negOffset;
        public bool overlap;
        public bool isPlayer = false;
        public bool canMove;

        public bool isLeft;
        public bool isRight;

        public int currFrame; 
        public int sheetSize; //will use to set how many sprites are on the sheet
        float timer;
        public int instance;
        public float interval; //interval between frames
 
        public float prevLocX;
        public float prevLocY;

        public Animation2d(string WALK, string I, Vector2 POS, Vector2 DIMS, Vector2 OFFSET, int SHEETSIZE, int HEALTH) //constructor
        {
            isAlive = true;

            isLeft = false;
            isRight = true;
            isHitting = false;
            canMove = true;
            
            if (HEALTH > 0)
            {
                health = HEALTH;
                hasHealth = true;
            }else
            {
                hasHealth = false;
            }

            interval = 75;
            walk = WALK;
            if (WALK != null)
            {
                texture = Globals.content.Load<Texture2D>(WALK);
            }
            
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
        public void setHealth(int HEALTH)
        {
            this.health = HEALTH;
            hasHealth = true;
        }
        public void setInterval(int INTERVAL)
        {
            interval = INTERVAL;
        }

        public void setPos(Vector2 POS)
        {
            pos = POS;
        }
        public virtual void Update(GameTime gameTime, List<Animation2d> entities) //updates animation
        {
            if (isAlive)
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
                    else if (prevLocY != pos.Y && prevLocX == pos.X || isHitting)
                    {
                        if (instance == 1)
                        {
                            AnimateRight(gameTime);
                        }
                        else if (instance == 2)
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

                }
                else if (!(sheetSize == 1) && idleTexture != null)
                {
                    AnimateIdle(gameTime);
                }

                if (entities != null)       //checks if Animation2ds are touching
                {
                    coolDown += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    foreach (var entity in entities)
                    {

                        if (entity == this)
                            continue;

                        if (this.isPlayer && !entity.isPlayer && this.isAlive)
                        {
                            if (this.pos.X - adjustHitbox <= entity.pos.X + entity.dims.X &&
                            this.pos.X + dims.X + adjustHitbox >= entity.pos.X &&
                            this.pos.Y <= entity.pos.Y + entity.dims.Y / 4 &&
                            this.pos.Y + this.dims.Y / 4 >= entity.pos.Y)
                            {
                                overlap = true;
                            }
                            else
                            {
                                overlap = false;
                            }


                            if (overlap && isHitting && entity.hasHealth && coolDown > 500 && entity.health != 0)
                            {
                                entity.color = Color.Red;
                                entity.canMove = false;
                                entity.health--;
                                Debug.WriteLine("enemy health: " + entity.health);
                                coolDown = 0;
                            }
                            else if (coolDown > 200)
                            {
                                entity.color = Color.White;
                                entity.canMove = true;
                            }
                            if (entity.health == 0 && entity.color != Color.Red)
                            {
                                entity.isAlive = false;
                                this.color = Color.White;

                            }
                        }
                        else if (!this.isPlayer && entity.isPlayer && entity.isAlive) {

                            if (this.pos.X - adjustHitbox <= entity.pos.X + entity.dims.X &&
                            this.pos.X + this.dims.X >= entity.pos.X &&
                            this.pos.Y <= entity.pos.Y + entity.dims.Y / 4 &&
                            this.pos.Y + this.dims.Y / 4 >= entity.pos.Y)
                            {
                                overlap = true;
                            }
                            else
                            {
                                overlap = false;
                            }
                            if (overlap && !entity.isHitting)
                            {
                                entity.color = Color.Red;
                            }
                            if (overlap && !entity.isHitting && coolDown > 800 && entity.health != 0)
                            {
                                entity.health--;
                                Debug.WriteLine("player health: " + entity.health);
                                coolDown = 0;
                                canMove = false;
                            }
                            else if (coolDown > 200)
                            {
                                entity.color = Color.White;
                                if (coolDown > 300)
                                {
                                    canMove = true;
                                }
                                
                            }
                            if (entity.health == 0 && entity.color != Color.Red)
                            { 
                                entity.isAlive = false;
                                this.color = Color.White;
                            }
                        }
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
            if (isAlive)
            {
                if (texture != null)
                {

                    if (isRight && !isLeft)
                    {
                        if (isHitting)
                        {
                            Vector2 v = new Vector2(-20, 0);
                            this.origin += v;
                        }
                        spriteBatch.Draw(texture, pos + offset, rectangle, color, 0f, origin, 1.0f, SpriteEffects.None, 0);
                    }
                    else if (isLeft && !isRight)
                    {
                        if (isHitting)
                        {
                            Vector2 v = new Vector2(20, 0);
                            this.origin += v;
                        }

                        spriteBatch.Draw(texture, pos + negOffset, rectangle, color, 0f, origin, 1.0f, SpriteEffects.None, 0);
                    }
                }

                else
                {
                    spriteBatch.Draw(idleTexture, pos + offset, rectangle, color, 0f, origin, 1.0f, SpriteEffects.None, 0);
                }
            }
        }
    }

}
