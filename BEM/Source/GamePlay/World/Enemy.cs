using BEM.Source.Engine;
using BEM.Source.Engine.Camera;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BEM.Source.GamePlay.World
{
    class Enemy : Animation2d
    {
        int screenLoc;
        private Vector2 velocity;
        private float speed;
        public Enemy(string WALK, string I, Vector2 POS, Vector2 DIMS, Vector2 OFFSET, int SHEETSIZE, int HEALTH) : base(WALK, I, POS, DIMS, OFFSET, SHEETSIZE, HEALTH)
        {
            isHitting = true;
            speed = 1f;
            adjustHitbox = 20;
            checkLock();
            setInterval(275);
        }

        public override void Update(GameTime gameTime, List<Animation2d> entities)
        {
            base.Update(gameTime, entities);
            pos += velocity;

            if ((pos != Player.playerPos && isAlive && screenLoc == Player.screenLoc && this.canMove && Player.alive) || (float)gameTime.ElapsedGameTime.TotalMilliseconds == 0)
            {
                if (pos.X > Player.playerPos.X)
                {
                    velocity.X = -speed;
                }else if (pos.X < Player.playerPos.X)
                {
                    velocity.X = speed;
                }else
                {
                    velocity.X = 0f;
                } 
                if (pos.Y + 20 < Player.playerPos.Y)
                {
                    velocity.Y = speed;
                }else if (pos.Y + 20 > Player.playerPos.Y)
                {
                    velocity.Y = -speed;
                }else
                {
                    velocity.Y = 0f;
                }
            }else
            {
                velocity = Vector2.Zero;
            }
        }

        private void checkLock()
        {
            int tempWidth = Globals.screenWidth;
            for (int i = 1; i <= 3 ; i++)
            {
                if (pos.X < tempWidth)
                {
                    this.screenLoc = i;
                    break;
                }
                tempWidth += Globals.screenWidth;
            }
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
