using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BEM
{
    class Basic2d
    {
        private Vector2 pos, dims;

        private SpriteEffects spriteEff;

        private Texture2D myModel;
        public Basic2d(string PATH, Vector2 POS, Vector2 DIMS)
        {
            pos = POS;
            dims = DIMS;

            spriteEff = new SpriteEffects();

            myModel = Globals.content.Load<Texture2D>(PATH);
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            if (myModel != null) { //makes sure model is set
                Globals._spriteBatch.Draw(myModel, new Rectangle((int)(pos.X), (int)(pos.Y), (int)(dims.X), (int)(dims.Y)), null, Color.White, 0.0f, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), spriteEff, 0);
                //                                 displays position and dimensions of object, can show part of image, color tint, rotation, point from where the image is drawn, Sprite Effects for opbject, layer depth 
            }
        }
    }
}
