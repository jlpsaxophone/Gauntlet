using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Gauntlet
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Gauntlet : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        ParticleSystem ShieldParticleSystem;
        Texture2D particleTexture;
        Random random = new Random();

        bool end = false;
        bool victory = false;
        double timer = 0;
        double timer2 = 0;
        double invincibility = 0;
        double laserCounter = 0;
        int laserCount = 15;
        bool fired = false;

        Ship player = new Ship();
        List<Laser> lasers = new List<Laser>();
        List<Meteor> meteors = new List<Meteor>();
        List<Explosion> explosions = new List<Explosion>();
        List<Powerup> powerups = new List<Powerup>();
        Planet earth;
        PlayerMessage win;
        PlayerMessage lose;
        SpriteFont text;
        Meteor meteorToRemove;
        Laser laserToRemove;
        Powerup poweruptoremove;

        public Gauntlet()
        {
            graphics = new GraphicsDeviceManager(this);
            earth = new Planet(this, graphics);
            Content.RootDirectory = "Content";
            win = new PlayerMessage(this, 2);
            lose = new PlayerMessage(this, 1);
            meteors.Add(new Meteor(this, graphics, 5, 5, 1));
            meteors.Add(new Meteor(this, graphics, 5, 122, 1));
            meteors.Add(new Meteor(this, graphics, 5, 244, 1));
            meteors.Add(new Meteor(this, graphics, 5, 366, 1));
            meteors.Add(new Meteor(this, graphics, 5, 488, 1));
            meteors.Add(new Meteor(this, graphics, 5, 610, 1));
            meteors.Add(new Meteor(this, graphics, 5, 727, 1));
            meteors.Add(new Meteor(this, graphics, 5, 844, 1));
            meteors.Add(new Meteor(this, graphics, 5, 961, 1));
            meteors.Add(new Meteor(this, graphics, 5, 1078, 1));
            meteors.Add(new Meteor(this, graphics, 5, 1195, 1));
            meteors.Add(new Meteor(this, graphics, 5, 1312, 1));
            meteors.Add(new Meteor(this, graphics, 5, 1429, 1));
            meteors.Add(new Meteor(this, graphics, 5, 1546, 1));
            meteors.Add(new Meteor(this, graphics, 5, 1663, 1));
            meteors.Add(new Meteor(this, graphics, 5, 1780, 1));
            meteors.Add(new Meteor(this, graphics, 5, 1897, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2014, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2131, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2248, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2365, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2482, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2599, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2716, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2833, 1));
            meteors.Add(new Meteor(this, graphics, 5, 2950, 1));
            meteors.Add(new Meteor(this, graphics, 5, 3067, 1));
            meteors.Add(new Meteor(this, graphics, 5, 3184, 1));
            meteors.Add(new Meteor(this, graphics, 5, 3301, 1));
            meteors.Add(new Meteor(this, graphics, 5, 3418, 1));
            meteors.Add(new Meteor(this, graphics, 5, 3535, 1));
            meteors.Add(new Meteor(this, graphics, 5, 3652, 1));
            meteors.Add(new Meteor(this, graphics, 5, 3769, 1));
            meteors.Add(new Meteor(this, graphics, 5, 3886, 1));
            meteors.Add(new Meteor(this, graphics, 5, 4003, 1));
            meteors.Add(new Meteor(this, graphics, 5, 4120, 1));
            meteors.Add(new Meteor(this, graphics, 5, 4237, 1));


            meteors.Add(new Meteor(this, graphics, 837, 5, 1));
            meteors.Add(new Meteor(this, graphics, 837, 122, 1));
            meteors.Add(new Meteor(this, graphics, 837, 244, 1));
            meteors.Add(new Meteor(this, graphics, 837, 366, 1));
            meteors.Add(new Meteor(this, graphics, 837, 488, 1));
            meteors.Add(new Meteor(this, graphics, 837, 610, 1));
            meteors.Add(new Meteor(this, graphics, 837, 727, 1));
            meteors.Add(new Meteor(this, graphics, 837, 844, 1));
            meteors.Add(new Meteor(this, graphics, 837, 961, 1));
            meteors.Add(new Meteor(this, graphics, 837, 1078, 1));
            meteors.Add(new Meteor(this, graphics, 837, 1195, 1));
            meteors.Add(new Meteor(this, graphics, 837, 1312, 1));
            meteors.Add(new Meteor(this, graphics, 837, 1429, 1));
            meteors.Add(new Meteor(this, graphics, 837, 1546, 1));
            meteors.Add(new Meteor(this, graphics, 837, 1663, 1));
            meteors.Add(new Meteor(this, graphics, 837, 1780, 1));
            meteors.Add(new Meteor(this, graphics, 837, 1897, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2014, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2131, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2248, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2365, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2482, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2599, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2716, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2833, 1));
            meteors.Add(new Meteor(this, graphics, 837, 2950, 1));
            meteors.Add(new Meteor(this, graphics, 837, 3067, 1));
            meteors.Add(new Meteor(this, graphics, 837, 3184, 1));
            meteors.Add(new Meteor(this, graphics, 837, 3301, 1));
            meteors.Add(new Meteor(this, graphics, 837, 3418, 1));
            meteors.Add(new Meteor(this, graphics, 837, 3535, 1));
            meteors.Add(new Meteor(this, graphics, 837, 3652, 1));
            meteors.Add(new Meteor(this, graphics, 837, 3769, 1));
            meteors.Add(new Meteor(this, graphics, 837, 3886, 1));
            meteors.Add(new Meteor(this, graphics, 837, 4003, 1));
            meteors.Add(new Meteor(this, graphics, 837, 4120, 1));
            meteors.Add(new Meteor(this, graphics, 837, 4237, 1));




            meteors.Add(new Meteor(this, graphics, 837, 3184, 1));
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 960;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent(Content);
            earth.LoadContent(Content);
            win.LoadContent(Content);
            text = Content.Load<SpriteFont>("File");
            lose.LoadContent(Content);
            foreach(Meteor m in meteors)
            {
                m.LoadContent(Content);
            }

            // TODO: use this.Content to load your game content here
            particleTexture = Content.Load<Texture2D>("particle");
            ShieldParticleSystem = new ParticleSystem(graphics.GraphicsDevice, 1000, particleTexture, spriteBatch);
            ShieldParticleSystem.Emitter = new Vector2(100, 100);
            ShieldParticleSystem.SpawnPerFrame = 4;

            // Set the SpawnParticle method
            ShieldParticleSystem.SpawnParticle = (ref Particle particle) =>
            {
                particle.Position = new Vector2((float)player.bounds.X + (float).5*player.bounds.Width - 10, (float)player.bounds.Y + (float).5 * player.bounds.Height);
                particle.Velocity = new Vector2(
                    MathHelper.Lerp(-100, 100, (float)random.NextDouble()), // X between -50 and 50
                    MathHelper.Lerp(-100, 100, (float)random.NextDouble()) // Y between 0 and 100
                    );
                particle.Acceleration = 0.5f * new Vector2(0, (float)-random.NextDouble());
                particle.Color = Color.CadetBlue;
                particle.Scale = 1f;
                particle.Life = 1f;
            };

            // Set the UpdateParticle method
            ShieldParticleSystem.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.Velocity += deltaT * particle.Acceleration;
                particle.Position += deltaT * particle.Velocity;
                particle.Scale -= deltaT;
                particle.Life -= deltaT;
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (fired == true)
            {
                laserCounter += gameTime.ElapsedGameTime.TotalSeconds;
                if(laserCounter >= 1)
                {
                    fired = false;
                    laserCounter = 0;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && fired == false)
            {              
                if(laserCount > 0 && fired == false)
                {
                    Laser l = new Laser(this, graphics, Convert.ToInt32(player.bounds.X + 30), Convert.ToInt32(player.bounds.Y));
                    l.LoadContent(Content);
                    lasers.Add(l);
                    laserCount--;
                    fired = true;
                }
                
            }

            foreach(Laser l in lasers)
            {
                l.Update(gameTime);
            }

            // TODO: Add your update logic here
            if(!(end || victory))
            {
                player.Update(gameTime);
            }           
            if(player.hasShields)
            {
                ShieldParticleSystem.Update(gameTime);
            }

            if(player.invincible)
            {
                invincibility += gameTime.ElapsedGameTime.TotalSeconds;
                if(invincibility >= 5)
                {
                    player.invincible = false;
                    invincibility = 0;
                }
            }

            timer2 += gameTime.ElapsedGameTime.TotalSeconds;
            if(timer2 >= 7)
            {
                int num = random.Next(1, 3);
                int bound = random.Next(117, 743);
                Powerup p = new Powerup(this, graphics, bound, Convert.ToInt32(player.bounds.Y - 580), num);
                p.LoadContent(Content);
                powerups.Add(p);
                timer2 = 0;
            }
            foreach(Powerup p in powerups)
            {
                p.Update(gameTime);
                if(Collisions.CollidesWith(player.bounds, p.bounds))
                {
                    poweruptoremove = p;
                    if(p.type == 1)
                    {
                        laserCount += 5;
                    }
                    if(p.type == 2)
                    {
                        player.hasShields = true;
                    }
                }
            }
            powerups.Remove(poweruptoremove);
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if(timer >= .5)
            {
                int temp = random.Next(1, 4);
                int bound = random.Next(117, 743);
                Meteor m = new Meteor(this, graphics, bound, Convert.ToInt32(player.bounds.Y - 580), temp);
                m.LoadContent(Content);
                meteors.Add(m);
                timer = 0;
            }

            foreach (Meteor m in meteors)
            {
                m.Update(gameTime);
                if(Collisions.CollidesWith(player.bounds, m.bounds))
                {
                    if(!player.invincible)
                    {
                        if(player.hasShields)
                        {
                            player.hasShields = false;
                            player.bounds.X = 450;
                            player.bounds.Y += 100;
                            player.invincible = true;
                        }
                        else
                        {
                            end = true;
                        }
                    }
                }
                if(lasers.Count > 0)
                {
                    foreach (Laser l in lasers)
                    {
                        if (Collisions.CollidesWith(m.bounds, l.bounds))
                        {
                            Explosion e = new Explosion(this, Convert.ToInt32(m.bounds.X + .5 * m.bounds.Width), Convert.ToInt32(m.bounds.Y + .5 * m.bounds.Height));
                            explosions.Add(e);
                            e.LoadContent(Content);
                            meteorToRemove = m;
                            laserToRemove = l;
                        }
                    }
                }              
            }
            meteors.Remove(meteorToRemove);
            lasers.Remove(laserToRemove);
            if(Collisions.CollidesWith(player.bounds, earth.bounds))
            {
                victory = true;
            }
            foreach(Explosion e in explosions)
            {
                e.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            var offset = new Vector2(450, 480) - new Vector2(player.bounds.X, player.bounds.Y);
            var t = Matrix.CreateTranslation(offset.X, offset.Y, 0);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, t);
            // TODO: Add your drawing code here
            foreach(Meteor m in meteors)
            {
                m.Draw(spriteBatch);
            }    
            foreach(Laser l in lasers)
            {
                l.Draw(spriteBatch);
            }
            if(player.hasShields)
            {
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, t);
                if(!victory)
                {
                    ShieldParticleSystem.Draw();
                }                
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, t);

            }
            if(!(end || victory))
            {
                player.Draw(spriteBatch);
            }         
            earth.Draw(spriteBatch);
            if(end && (!victory))
            {
                lose.bounds.X = player.bounds.X - 218;
                lose.bounds.Y = player.bounds.Y;
                lose.Draw(spriteBatch);
            }
            if (victory)
            {
                win.bounds.X = player.bounds.X - 218;
                win.bounds.Y = player.bounds.Y - 100;
                win.Draw(spriteBatch);
            }
            spriteBatch.DrawString(
                text,
                "Ammo: " + laserCount.ToString(),
                new Vector2(player.bounds.X - 440, player.bounds.Y - 455),
                Color.Red
                );
            foreach (Explosion e in explosions)
            {
                e.Draw(spriteBatch);
            }
            foreach(Powerup p in powerups)
            {
                p.Draw(spriteBatch);
            }
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
