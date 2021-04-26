using Microsoft.Xna.Framework;
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
    class Player : Character_Assets
    {

        public float punchTime;
        public static Vector2 playerPos;
        public static bool hitting;
        public static bool alive;
        public static int hPoints;
        public Player(string WALK, string I, Vector2 POS, Vector2 DIMS, Vector2 OFFSET, int SHEETSIZE, int HEALTH) : base(WALK, I, POS, DIMS, OFFSET, SHEETSIZE, HEALTH)
        {
            //health = HEALTH;
            isAlive = true;
            isPlayer = true;

        }

        public override void Update(GameTime gameTime, List<Animation2d> entities) //updates sprite
        {
            if (isAlive)
            {
                punchTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (Globals.keyState.IsKeyDown(Keys.J) && !isHitting && !isJumping && punchTime > 500 && !isWalking)
                {
                    punchTime = 0;
                    dims.X = 80;
                    this.texture = Globals.content.Load<Texture2D>("bin//Windows/Content//nerd_punch");
                    isHitting = true;
                }
                if (isHitting)
                {
                    adjustHitbox = 24;
                    if (this.currFrame == 3 || this.currFrame == 7)
                    {
                        isHitting = false;
                    }
                }
                if (isHitting == false)
                {
                    adjustHitbox = 0;
                    dims.X = 56;
                    this.texture = Globals.content.Load<Texture2D>(this.walk);
                }

                hitting = isHitting;
                playerPos = pos;
                hPoints = health;
                //base.Update(gameTime, entities);
            }
            base.Update(gameTime, entities);
            alive = isAlive;
        }

        public override void Draw(SpriteBatch spriteBatch) //draws sprite on screen
        {
            if (isAlive)
            {
                base.Draw(spriteBatch);
            }

        }
    }
}
