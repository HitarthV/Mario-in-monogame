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
    //animations manager class that will control all the animations
    public class AnimationsManager
    {
        //variables and properties listed for the class
        private Animations animation;
        private float timer;
        public Vector2 position { get; set; }
        public AnimationsManager(Animations _animation)
        {
            animation = _animation;
        }
        //draw method to draw a sprite whilst animating 
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animation.texture, position, new Rectangle(animation.currentFrame * animation.frameWidth, 0, animation.frameWidth, animation.frameHeight), Color.White);
        }
        //playing the animation using the animations class and the timer to loop it 
        public void Play(Animations _animation)
        {
            if (animation == _animation)
            {
                return;
            }
            animation = _animation;
            animation.currentFrame = 0;
            timer = 0;
        }
        //stop the animations when called 
        public void Stop()
        {
            timer = 0f;
            animation.currentFrame = 0;
        }
        //update the animations and the timer when the animations are playing or have been called to stop
        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > animation.frameSpeed)
            {
                timer = 0f;
                animation.currentFrame++;

                if (animation.currentFrame >= animation.frameCount)
                {
                    animation.currentFrame = 0;
                }
            }
        }
    }
}

