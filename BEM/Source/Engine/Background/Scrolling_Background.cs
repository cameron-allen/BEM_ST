using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace BEM
{                                               //this class from https://www.youtube.com/watch?v=NZEzD0GvImg&t=304s
    public class Scrolling_Background
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    public class Scrolling : Scrolling_Background
    {
        public Scrolling(Texture2D newText, Rectangle newRect)
        {
            texture = newText;
            rectangle = newRect;
        }

        public void Update()
        {
            rectangle.X -= 3;
        }
    }
}
