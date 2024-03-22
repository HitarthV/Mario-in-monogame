using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;
using System.Reflection.Metadata;

namespace MarioPlatformerClone
{
    //animations class that will set the base for the animations
    public class Animations
    {
        //variables to be used for the frames eg current frame, frameHeight, frameWidth,etc. isLooping is used to check if the animation is looping and the texture
        public int currentFrame {  get; set; }
        public int frameCount { get; private set; }
        public int frameHeight { get { return texture.Height; } }
        public float frameSpeed { get; set; }
        public int frameWidth { get { return texture.Width / frameCount; } }
        public bool isLooping { get; set; }
        public Texture2D texture { get; private set; }
        //animations subroutine so when called I can use it to use the animations using my sprites
        public Animations(Texture2D _texture, int _frameCount)
        {
            texture = _texture;
            frameCount = _frameCount;
            isLooping = true;
            frameSpeed = 0.2f;
        }

    }
}
