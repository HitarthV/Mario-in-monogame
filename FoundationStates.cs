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
using SharpDX.XInput;

namespace MarioPlatformerClone
{
    public abstract class FoundationStates
    {
        //defining variables that will be used to get for the class foundation states subroutine later on
        #region fields
        protected ContentManager content;

        protected GraphicsDevice graphicsDevice;

        protected Main main;
        #endregion
        //defining methods to be inherited from later on
        #region methods
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void post_Update(GameTime gameTime);

        public FoundationStates (Main _main, GraphicsDevice _graphicsDevice, ContentManager _content)
        {
            main = _main;
            graphicsDevice = _graphicsDevice;
            content = _content;
        }

        public abstract void Update (GameTime gameTime);
        #endregion
    }
}
