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
using SharpDX.Direct3D9;

namespace MarioPlatformerClone
{
    class JumpCharacter
    {
        //variables for the class that have been defined 
 
        Texture2D texture;
        Vector2 position;
        Vector2 velocity;
        private Rectangle rectangle;
        bool hasJumped;

        
       //jump character subroutine so when a sprite is drawn I can call this method
        public JumpCharacter(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            position = _position;
            hasJumped = true;
        }
       
        //update method to update the sprite
        public void Update(GameTime gameTime) 
        {
            //selection statements to check if the player has jumped and the following procedures after the player has jumped to bring the player back down using gravity
            position += velocity;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            { velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3; }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            { velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3; }
            else
            { velocity.X = 0f; }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && hasJumped == false)
            {
                position.Y -= 5f;
                velocity.Y = -9f;
                hasJumped = true;
            }
            if (hasJumped == true)
            {
                float i = 1;
                velocity.X += 0.2f * i;
                velocity.Y -= 2f * i;
            }
            if(position.Y + texture.Height >= 10) 
            {
                hasJumped = false;
            }
            if(hasJumped == false)
            {
                velocity.Y = 2f;
            }
        }
        public void Collision(Rectangle _rectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(_rectangle))
            {
                rectangle.Y = _rectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            if (rectangle.TouchLeftOf(_rectangle))
            {
                position.X = _rectangle.X - rectangle.Width - 2;
            }
            if (rectangle.TouchRightOf(_rectangle))
            {
                position.X = _rectangle.X + rectangle.Width + 2;
            }
            if (rectangle.TouchBottomOf(_rectangle))
            {
                velocity.Y = 1f;
            }
            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.X > xOffset - rectangle.Width)
            {
                position.X = xOffset - rectangle.Width;
            }
            if (position.Y < 0)
            {
                velocity.Y = 1f;
            }
            if (position.Y > yOffset - rectangle.Height)
            {
                position.Y = yOffset - rectangle.Height;
            }
        }
        //draw method to draw the sprite
        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(texture, position,Color.White);
        }

      
    }
}
