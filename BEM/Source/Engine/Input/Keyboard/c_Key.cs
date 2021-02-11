#region Includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
    public class c_Key              //entire class created here https://www.youtube.com/watch?v=09fiMG4lxhA&list=PLZ6ofHM1rvK8lQSoKX1USZstM-ZXikFHp&index=2
    {
        public int state;
        public string key, print, display;

        public object Control { get; private set; }

        //public object Control { get; private set; }

        public c_Key(string KEY, int STATE)
        {
            key = KEY;
            state = STATE;
            MakePrint(key);
        }

        public virtual void Update()
        {
            state = 2;

        }


        public void MakePrint(string KEY)
        {
            display = KEY;

            string tempStr = "";

            if(KEY == "A" || KEY == "B" || KEY == "C" || KEY == "D" || KEY == "E" || KEY == "F" || KEY == "G" || KEY == "H" || KEY == "I" || KEY == "J" || KEY == "K" || KEY == "L" || KEY == "M" || KEY == "N" || KEY == "O" || KEY == "P" || KEY == "Q" || KEY == "R" || KEY == "S" || KEY == "T" || KEY == "U" || KEY == "V" || KEY == "W" || KEY == "X" || KEY == "Y" || KEY == "Z")
            {
                tempStr = KEY;
            }
            if(KEY == "Space")
            {
                tempStr = " ";
            }
            if (KEY == "Shift")
            {

            }
            if(KEY == "OemCloseBrackets")
            {
                tempStr = "]";
                display = tempStr;
            }
            if(KEY == "OemOpenBrackets")
            {
                tempStr = "[";
                display = tempStr;
            }
            if(KEY == "OemMinus")
            {
                tempStr = "-";
                display = tempStr;
            }
            if(KEY == "OemPeriod" || KEY == "Decimal")
            {
                tempStr = ".";
            }
            if(KEY == "D1" || KEY == "D2" || KEY == "D3" || KEY == "D4" || KEY == "D5" || KEY == "D6" || KEY == "D7" || KEY == "D8" || KEY == "D9" || KEY == "D0")
            {
                tempStr = KEY.Substring(1);
            }
            else if(KEY == "NumPad1" || KEY == "NumPad2"  || KEY == "NumPad3" || KEY == "NumPad4" || KEY == "NumPad5" || KEY == "NumPad6" || KEY == "NumPad7" || KEY == "NumPad8" || KEY == "NumPad9" || KEY == "NumPad0")
            {
                tempStr = KEY.Substring(6);
            }


            print = tempStr;
        }
    }
}
