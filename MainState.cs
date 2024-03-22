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
    //inheriting from foundation states class as it lays a foundation of the other states that can be used
    public class MainState : FoundationStates
    {
        //another class that inherits from foundation states which is useful for changing the state of the program when run
        private List<Sprites> sprites;
        JumpCharacter player;
       
        //initializer for the intializing of the variables that will be needed in my main state class
        public void Initialize()
        {
            
        }
        //the mainstate class that is essential for the game as when play game is clicked this is the state that will be present
        public MainState(Main _main, GraphicsDevice _graphicsDevice, ContentManager _content) : base(_main, _graphicsDevice, _content)
        {
            //variables to load the player in using different animations 
            var animations = new Dictionary<string, Animations>()
            {
                {"WalkRight",new Animations(content.Load<Texture2D>("2D/MarioWalkRight"),7) },
                {"WalkLeft",new Animations(content.Load<Texture2D>("2D/marioWalkLeft"),7) },
                {"Jump",new Animations(content.Load<Texture2D>("2D/marioJump"),1) },
                {"Idle",new Animations(content.Load<Texture2D>("2D/marioIdle"),1) },
            };
            sprites = new List<Sprites>()
            {  
                new Sprites(animations)
                {
                    position = new Vector2(20,250),
                    inputs = new Inputs()
                    {
                        Jump = Keys.Up,
                        Left = Keys.Left,
                        Right = Keys.Right,
                    },
                },
            };
            player = new JumpCharacter(content.Load<Texture2D>("2D/marioJump"), new Vector2(25, 300));
            

        }
        //draw method to draw the variables in the mainstate subroutine 
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach(var sprite in sprites) 
            {
                sprite.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            spriteBatch.End();
        }
        //update methods the post update is empty as it has to be for the state to change and the update method is there to update the variables in the mainstate subroutine
        public override void post_Update(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
           foreach (var sprite in sprites)
           {
                sprite.Update(gameTime,sprites);
           }
           player.Update(gameTime);
        }
    }
}
