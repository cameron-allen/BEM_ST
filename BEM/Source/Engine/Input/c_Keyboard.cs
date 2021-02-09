#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
#endregion

namespace BEM
{
    public class c_Keyboard     //entire class created here https://www.youtube.com/watch?v=09fiMG4lxhA&list=PLZ6ofHM1rvK8lQSoKX1USZstM-ZXikFHp&index=2
    {
                             //new frame, previous frame
        public KeyboardState newKeyboard, oldKeyboard;

        public List<c_Key> pressedKeys = new List<c_Key>(), previousPressedKeys = new List<c_Key>();

        public c_Keyboard()
        {

        }

        public virtual void Update()
        {
            newKeyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();

            GetPressedKeys();

        }

        public void UpdateOld()
        {
            oldKeyboard = newKeyboard;

            previousPressedKeys = new List<c_Key>();
            for(int i=0;i<pressedKeys.Count;i++)
            {
                previousPressedKeys.Add(pressedKeys[i]);
            }
        }


        public bool GetPress(string KEY)
        {

            for(int i=0;i<pressedKeys.Count;i++)
            {

                if(pressedKeys[i].key == KEY)
                {
                    return true;
                }

            }
            

            return false;
        }


        public virtual void GetPressedKeys()
        {
            bool found = false;

            pressedKeys.Clear();
            for(int i=0; i<newKeyboard.GetPressedKeys().Length; i++)
            {

                    pressedKeys.Add(new c_Key(newKeyboard.GetPressedKeys()[i].ToString(), 1));
  
            }
        }

    }
}
