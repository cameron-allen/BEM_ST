using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BEM //write more comments ya foolh
{
    public class Basic2d
    {
        public Vector2 pos, dims;

        public float rot;

        public SpriteEffects spriteEff;     //later on I can import sprite effects with this

        public Texture2D myModel;       //allows me to import a sprite
        public Basic2d(string PATH, Vector2 POS, Vector2 DIMS)      //initializations
        {
            pos = POS;
            dims = DIMS;

            spriteEff = new SpriteEffects();

            myModel = Globals.content.Load<Texture2D>(PATH);
        }

        public void ChangePath(string path)
        {
            myModel = Globals.content.Load<Texture2D>(path);
            //myModel.Reload();
        }

        public virtual void Update(Vector2 OFFSET)
        {
            pos += OFFSET;
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (myModel != null) { //makes sure model is set
                Globals._spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)(dims.X), (int)(dims.Y)), null, Color.White, rot, new Vector2(myModel.Bounds.Width / 2, myModel.Bounds.Height / 2), spriteEff, 0);
                //                                 displays position and dimensions of object, can show part of image, color tint, rotation, point from where the image is drawn, Sprite Effects for opbject, layer depth 
            }
        }
        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {
            if (myModel != null)
            { //makes sure model is set
                Globals._spriteBatch.Draw(myModel, new Rectangle((int)(pos.X + OFFSET.X), (int)(pos.Y + OFFSET.Y), (int)(dims.X), (int)(dims.Y)), null, Color.White, rot, new Vector2(ORIGIN.X, ORIGIN.Y), spriteEff, 0);
                //                                 displays position and dimensions of object, can show part of image, color tint, rotation, point from where the image is drawn, Sprite Effects for opbject, layer depth 
            }
        }
    }
}
