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
using System.Runtime.Intrinsics;


namespace MarioPlatformerClone
{
    //touch the tile class which will be used to check if the player has touched the tiles
    static class TouchTile
    {
        //touching the top of the tile subroutine to check if the player touches the tile on top of it
        public static bool TouchTopOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Bottom >= r2.Top - 1 && r1.Bottom <= r2.Top + (r2.Height / 2) && r1.Right >= r2.Left + (r2.Width / 5 ) && r1.Left <= r2.Right - (r2.Width / 5));
        }
        //if the player hits the bottom of the tile then it will make the player collide with it and bounce the player back off
        public static bool TouchBottomOf(this Rectangle r1, Rectangle r2) 
        {
            return (r1.Top <= r2.Bottom + (r2.Height / 5) && r1.Top >= r2.Bottom - 1 && r1.Right >= r2.Left + (r2.Width / 5) && r1.Left <= r2.Right - (r2.Width / 5));
        }
        //if the player hits the left of the tile then it will make the player collide with it and bounce the player back off
        public static bool TouchLeftOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Right <= r2.Right && r1.Right >= r2.Left - 5 && r1.Top <= r2.Bottom - (r2.Width / 4) && r1.Bottom >= r2.Top + (r2.Width / 4));
        }
        //if the player hits the right of the tile then it will make the player collide with it and bounce the player back off
        public static bool TouchRightOf(this Rectangle r1, Rectangle r2)
        {
            return (r1.Left >= r2.Left && r1.Left <= r2.Right + 5 && r1.Top <= r2.Bottom - (r2.Width / 4) && r1.Bottom >= r2.Top + (r2.Width / 4));
        }
    }
}
