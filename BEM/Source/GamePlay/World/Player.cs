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
        public Player(string WALK, string I, Vector2 POS, Vector2 DIMS, Vector2 OFFSET, int SHEETSIZE) : base(WALK, I, POS, DIMS, OFFSET, SHEETSIZE)
        {
            isMain = true;
        }

        public override void Update(GameTime gameTime, List<Animation2d> entities) //updates sprite
        {
            punchTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (Globals.keyState.IsKeyDown(Keys.J) && !isPunching && !isJumping && punchTime > 500 && !isWalking)
            {
                punchTime = 0;
                dims.X = 80;
                this.texture = Globals.content.Load<Texture2D>("bin//Windows/Content//nerd_punch");
                isPunching = true;
            }
            if (isPunching)
            {
                if (this.currFrame == 3 || this.currFrame == 7)
                {
                    isPunching = false;
                }
            }
            if (isPunching == false)
            {
                dims.X = 56;
                this.texture = Globals.content.Load<Texture2D>(this.walk);
            }

            base.Update(gameTime, entities);
        }

        public override void Draw(SpriteBatch spriteBatch) //draws sprite on screen
        {

            base.Draw(spriteBatch);

        }
    }
}
