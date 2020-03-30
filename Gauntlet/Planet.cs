using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Gauntlet
{
    public class Planet
    {
        Gauntlet game;
        GraphicsDeviceManager graphics;
        public BoundingRectangle bounds = new BoundingRectangle();
        Texture2D texture;

        public Planet(Gauntlet game, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphics = graphics;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("earth");
            bounds.X = 413;
            bounds.Y = 10;
            bounds.Width = 120;
            bounds.Height = 120;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
