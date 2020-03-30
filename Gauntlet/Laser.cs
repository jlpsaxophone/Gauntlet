using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Gauntlet
{
    public class Laser
    {
        Gauntlet game;
        GraphicsDeviceManager graphics;

        int bound1;
        int bound2;
        public BoundingRectangle bounds = new BoundingRectangle();
        Texture2D texture;

        public Laser(Gauntlet game, GraphicsDeviceManager graphics, int bound1, int bound2)
        {
            this.game = game;
            this.graphics = graphics;
            this.bound1 = bound1;
            this.bound2 = bound2;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("laser");
            bounds.X = bound1;
            bounds.Y = bound2;
            bounds.Width = 6;
            bounds.Height = 15;
        }

        public void Update(GameTime timeSpan)
        {
            bounds.Y -= (float)(.5 * timeSpan.ElapsedGameTime.TotalMilliseconds);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
