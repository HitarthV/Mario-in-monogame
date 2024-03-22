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
using System.Windows.Forms;
using SharpDX.Direct3D9;

namespace MarioPlatformerClone
{
    public class Sprites
    {
        //fields that will be used in the class 
        #region Fields
        protected AnimationsManager animationsManager;
        protected Dictionary<string, Animations> animations;
        protected Texture2D texture;
        protected Vector2 _position;
        #endregion
        //properties that are essential for the class,some with getters and setters
        #region Properties
        public Inputs inputs;
        public Vector2 position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (animationsManager != null)
                {
                    animationsManager.position = _position;
                }
            }
        }
        public float speed = 1f;
        public Vector2 velocity;
        #endregion

        //methods region 
        #region Methods
        //draw method to say that if the texture is not null then it will draw the sprite and if the animations manager is not null then it will animate 
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
            else if (animationsManager != null)
            {
                animationsManager.Draw(spriteBatch);
            }
            else throw new Exception("Thou have failed");
        }
        //move method to say that when a key is pressed from the inputs class the move method will make sure the player moves by assigning velocity a value
        protected virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(inputs.Jump))
            { velocity.Y = -speed; }
            else if (Keyboard.GetState().IsKeyDown(inputs.Left))
            { velocity.X = -speed; }
            else if (Keyboard.GetState().IsKeyDown(inputs.Right))
            { velocity.X = speed; }
            else
            {
                velocity.X = 0;
                velocity.Y = 0;
            }
        }
        //setting animations for different things such as walkright, walkleft and jump and idle and selections depending on the velocity
        protected virtual void SetAnimations()
        {
            if (velocity.X > 0)
            { animationsManager.Play(animations["WalkRight"]); }
            if (velocity.X < 0)
            { animationsManager.Play(animations["WalkLeft"]); }
            if (velocity.Y < 0)
            { animationsManager.Play(animations["Jump"]); }
            if (velocity.X == 0 && velocity.Y == 0)
            {
                animationsManager.Play(animations["Idle"]);
            }
        }
        //sprites subroutines for the class one for the texture and one to use a dictionary so I can list the animations in the main state class
        public Sprites(Texture2D _texture)
        {
            texture = _texture;
            
        }
        public Sprites(Dictionary<string, Animations> _animations)
        {

            animations = _animations;
            animationsManager = new AnimationsManager(animations.First().Value);
        }
        //update method that will update the animations the movements and the player itself
        public void Update(GameTime gameTime, List<Sprites> sprites)
        {
            SetAnimations();
            Move();
            animationsManager.Update(gameTime);
            _position += velocity;
            velocity = Vector2.Zero;

        }
        #endregion
    }
}

