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
    public class Players
    {
        //variables for the player class that will be used in the class
        private Texture2D texture;
        private Vector2 position = new Vector2(57, 148);
        private Vector2 velocity;
        private Rectangle rectangle;

        private bool hasJumped = false;
        //properties with getters and setters 
        private Vector2 Position
        {
            get { return position; }
        }
        public Players(Texture2D _texture) 
        {
            texture = _texture;
        }
        //update method to update the rectangle that will collide with the player
        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }
        }
        //input subroutine that will get the state of the input and assign a velocity value depending on the input
        private void Input(GameTime gameTime)
        {
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
        }
        //collision method to say if the player has touched the blocks or not and which side of the block the player has touched
        public void Collision(Rectangle _rectangle, int xOffset, int  yOffset)
        {
            if(rectangle.TouchTopOf(_rectangle))
            {
                rectangle.Y = _rectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            if(rectangle.TouchLeftOf(_rectangle))
            {
                position.X = _rectangle.X - rectangle.Width - 2 ;
            }
            if (rectangle.TouchRightOf(_rectangle)) 
            {
                position.X =_rectangle.X + rectangle.Width + 2 ;
            }
            if(rectangle.TouchBottomOf(_rectangle))
            {
                velocity.Y = 1f;
            }
            if (position.X < 0)
            {
                position.X = 0;
            }
            if(position.X > xOffset - rectangle.Width) 
            {
                position.X = xOffset - rectangle.Width; 
            }
            if(position.Y < 0)
            {
                velocity.Y = 1f;
            }
            if(position.Y > yOffset - rectangle.Height)
            {
                position.Y = yOffset - rectangle.Height;
            }
        }
        //draw method to draw the sprite
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle,Color.White);
        }
    }
}
