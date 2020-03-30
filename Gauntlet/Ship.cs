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
    public class Ship
    {       
        public BoundingRectangle bounds = new BoundingRectangle();

        Texture2D texture;
        public bool hasShields = true;
        public bool invincible = false;


        public Ship()
        {
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ship");
            bounds.Width = 60;
            bounds.Height = 64;
            bounds.X = 450;
            bounds.Y = 4237;
        }

        public void Update(GameTime timeSpan)
        {
            var newKeyboardState = Keyboard.GetState();
            if (newKeyboardState.IsKeyDown(Keys.Up))
            {
                bounds.Y -= (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
            }

            if (newKeyboardState.IsKeyDown(Keys.Down))
            {
                bounds.Y += (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
            }

            if (newKeyboardState.IsKeyDown(Keys.Left))
            {
                bounds.X -= (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
            }

            if (newKeyboardState.IsKeyDown(Keys.Right))
            {
                bounds.X += (float)(.3 * timeSpan.ElapsedGameTime.TotalMilliseconds);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
