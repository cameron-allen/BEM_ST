﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using BEM.Source.Engine.Camera;
using BEM.Source.Engine;

namespace BEM.Source.GamePlay.World
{
    class MainChar : Animation2d
    {
        float sprint = 1;

        bool isJumping;
        bool isWalking;
        float initPos;
        float punchTime;

        public MainChar(string WALK, string I, Vector2 POS, Vector2 DIMS, int SHEETSIZE) : base(WALK, I, POS, DIMS, SHEETSIZE)
        {
            isJumping = false;
            setInterval(200);
        }

        private void updMove(GameTime gameTime)
        {
            pos += velocity;
            setInterval(200);
            punchTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            isWalking = false;

            //this block if code is from https://www.youtube.com/watch?v=ZLxIShw-7ac
            //with the exception of the initial position implementation. I came up with this so the jump stops where the jump started
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && isJumping == false)        //detects if the spirte is jumping when space is pressed (prevents spam jumping)
            {
                initPos = pos.Y; //inital position equals Y coordinate when space is spressed
                pos.Y -= 10f;
                velocity.Y = -5f;
                isJumping = true;
            }
            if (isJumping == true)  //if isJumping, velocity downward gradually increases (aka gravity)
            {
                if (instance == 1)
                {
                    currFrame = 0;
                }else
                {
                    currFrame = 4;
                }
                float i = 1;
                velocity.Y += 0.25f * i;
            }
            if (pos.Y >= initPos) //if the current Y coordinate is greater than the initial position, the sprite isn't jumping 
            {
                isJumping = false;
            }
            if (isJumping == false)
            {
                velocity.Y = 0f;
            }
            //block of code ends
            
            if (Globals.keyState.IsKeyDown(Keys.LeftShift))     //increases speed of movenment when shift is down (aka sprint)
            {
                //Debug.WriteLine(pos.X);
                setInterval(100);
                sprint = (float)2.5;
            }
            else
            {
                sprint = 1;
            }

            if (Globals.keyState.IsKeyDown(Keys.A))     //if A key is pressed. go left and flip sprite if it isn't already flipped
            {

                if (pos.X > 30)
                {
                    pos = new Vector2(pos.X - 2 * sprint, pos.Y);
                }

                isWalking = true;
            }
            if (Globals.keyState.IsKeyDown(Keys.S)) //if S key is pressed & sprite isn't jumping. go down
            {
                if (isJumping != true)
                {
                    if (pos.Y <= 292)
                    {
                        pos = new Vector2(pos.X, pos.Y + 2 * sprint);
                    }
                   
                }
                isWalking = true;
            }
            if (Globals.keyState.IsKeyDown(Keys.D))     //if D key is pressed. go right and flip sprite if it isn't already flipped
            {

                if (pos.X < (Globals.screenWidth * 3) - 30)
                {
                    pos = new Vector2(pos.X + 2 * sprint, pos.Y);
                }
                isWalking = true;

            }
            if (Globals.keyState.IsKeyDown(Keys.W))     //if W key is pressed & sprite isn't jumping. go up
            {
                
                if (isJumping != true)
                {
                    if (pos.Y >= 145)
                    {
                        pos = new Vector2(pos.X, pos.Y - 2 * sprint);
                    }
                   
                }
                isWalking = true;
            }
            if (Globals.keyState.IsKeyDown(Keys.J) && !isPunching && !isJumping && punchTime > 500 && !isWalking)
            {
                punchTime = 0;
                dims.X = 80;
                this.texture = Globals.content.Load<Texture2D>("bin//Windows/Content//nerd_punch");
                isPunching = true;
            }if (isPunching)
            {
                setInterval(45);
                if (this.currFrame == 3 || this.currFrame == 7)
                {
                    isPunching = false;
                    setInterval(75);
                }
            }
            if (isPunching == false)
            {
                dims.X = 56;
                this.texture = Globals.content.Load<Texture2D>(this.walk);
            }

        }

        public override void Update(GameTime gameTime, List<Animation2d> entities) //updates sprite
        {
            updMove(gameTime);
            base.Update(gameTime, entities);
        }

        public override void Draw(SpriteBatch spriteBatch) //draws sprite on screen
        {
            
            base.Draw(spriteBatch);
            
        }
    }
}
