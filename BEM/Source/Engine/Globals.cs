using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BEM
{
    public delegate void PassObject(object i);
    public delegate object PassObjectAndReturn(object i);
    public class Globals
    {
        public static ContentManager content;
        public static SpriteBatch _spriteBatch;
        public static KeyboardState keyState;
        public static int screenWidth;
        public static int screenHeight;

        public static GameTime time;
    }
}
