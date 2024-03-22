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

namespace MarioPlatformerClone
{
    //abstract so child classes can inherit from this parent class 
    public abstract class Globals
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch); //using this abstract procedure to draw sprites across the classes that inherit from Globals

        public abstract void Update(GameTime gameTime); //using this abstract procedure to update my drawn sprites across the classes that inherit from Globals

    }
}
