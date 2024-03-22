using MarioPlatformerClone;
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
using System.ComponentModel;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using SharpDX.XInput;
using System.Diagnostics;

namespace MarioPlatformerClone
{
    public class Main : Game
    {
        //defining key variables that will be essential for the game in the main game
        GraphicsDeviceManager graphics;
        private ContentManager content;
        private SpriteBatch spriteBatch;
        private FoundationStates currentState;
        private FoundationStates nextState;
        private Color backgroundColor = Color.CornflowerBlue;
        MapMaker map;
        Players player;
        public static int screenHeight;
        public static int screenWidth;
        private Song audio;
        //changing state subroutine to allow the screen to change state when play game is clicked
        public void ChangingState(FoundationStates state)
        {
            //variable nextState that will allow be to store a state in it whilst the other states switch
            nextState = state;
            //map generating method that is essential for the map to load into the game
            map.Generate(new int[,]
                {
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,15,14,13,13,14,15,15,15,13,0,0,0,0,0,13,14, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
                {0,0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7, },
                {10,10, 10, 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10, },
                }, 32);
            player = new Players(Content.Load<Texture2D>("2D/marioJump"));

        }
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        //intializer to initialize my variables
        protected override void Initialize()
        {
            IsMouseVisible = true;
            map = new MapMaker();
            player = new Players(Content.Load<Texture2D>("2D/marioJump"));
            screenHeight = graphics.PreferredBackBufferHeight;
            screenWidth = graphics.PreferredBackBufferWidth;
            base.Initialize();
        }
       
        protected override void LoadContent()
        {
            // loads the song
            audio = Content.Load<Song>("Audio/marioSong"); 
            // makes song loop
            MediaPlayer.IsRepeating = true;
            // loop the song and then play it
            MediaPlayer.Play(audio); 
            //using the load content to load new sprites
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //getting current state from the menu class
            currentState = new Menu(this, graphics.GraphicsDevice, Content);
            Tiles.Content = Content;
            
        }

        protected override void Update(GameTime gameTime)
        {
            //telling the update function to swap the current state and next state around 
            player.Update(gameTime);
            //adding collisions in the game with the map
            foreach (CollidingTiles tiles in map._collidingTiles)
            {
                player.Collision(tiles.Rectangle, map._width, map._height);
            }
            if (nextState != null)
            {
                currentState = nextState;
                nextState = null;
                
            }
           
            currentState.Update(gameTime);
            currentState.post_Update(gameTime);
            
            
            base.Update(gameTime);
            
        }
        //draw method to draw the variables in this class
        protected override void Draw(GameTime gameTime)
        {
            //telling monogame to make the color the variable backgroundColor
            GraphicsDevice.Clear(backgroundColor);
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            spriteBatch.End();
            currentState.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
    }
}
