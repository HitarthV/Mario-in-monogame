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
    class MapMaker
    {
        //use the colliding tiles class that inherits from tiles.cs to make this class work optimally
        private List<CollidingTiles> collidingTiles = new List<CollidingTiles>();

        //getters and setters for the variables 
        public List<CollidingTiles> _collidingTiles
        {
            get { return collidingTiles; }
        }

        private int height,width;
        public int _height
        {
            get { return height; } 
        }
        public int _width
        {
            get { return width; }
        }
        //class procedure to make sure no build errors occur
        public MapMaker() { }

        //main procedure of the class that will actually generate the map using a matrix 
        public void Generate(int[,] map, int size)
        {
            //this for loop is to loop through the different x axis numbers along the x direction in the array and the same goes for the y nested for loop
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    //the number is the map variable array but the x and y are backwards since thats how the vectors will work on monogame to be able to draw the tiles
                    int number = map[y, x];
                    //to say that if the number in the matrix is greater than 0 then it will draw a new rectangle that has been set using the x, y and size variables
                    if(number > 0)
                    {
                        collidingTiles.Add(new CollidingTiles(number, new Rectangle (x * size, y * size, size, size)));
                    }
                    //if x and y are 0 then the width and height cant just be zero so using this we have to add 1 and then multiply by the sizw
                    width = (x+1) * size;
                    height = (y+1) * size;
                }
            }
        }
        //this is used to actually draw the tiles listed in the generate method
        public void Draw (SpriteBatch spriteBatch)
        {
            foreach (CollidingTiles tile in collidingTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}
