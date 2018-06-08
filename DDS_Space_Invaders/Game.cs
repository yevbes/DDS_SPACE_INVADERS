using Invaders.Factory;
using Invaders.Patterns.Non_Gamma_patterns.Null_Object;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Invaders
{
    class Game : IGame
    {
        private Stars stars;
        private Rectangle formArea;
        private Random random;
        private Levels nivel;

        private int score = 0;
        private int livesLeft = 4;

        private int currentGameFrame = 1;

        private List<Invader> invaders;

        private PlayerShip playerShip;
        private List<Shot> playerShots;
        private List<Shot> invaderShots;

        private PointF scoreLocation;
        private PointF livesLocation;
        private PointF waveLocation;

        private int numShots = 2;

        Font messageFont = new Font(FontFamily.GenericMonospace, 50, FontStyle.Bold);
        Font statsFont = new Font(FontFamily.GenericMonospace, 15);

        public Game(Random random, Rectangle formArea)
        {
            this.formArea = formArea;
            this.random = random;

            // Se crea un objeto con una Lista de Estrellas con su posición y el color
            stars = new Stars(random, formArea);

            // Crea los labels en la posición del rectangulo
            scoreLocation = new PointF((formArea.Left + 5.0F), (formArea.Top + 5.0F));
            livesLocation = new PointF((formArea.Right - 120.0F), (formArea.Top + 5.0F));
            waveLocation = new PointF((formArea.Left + 5.0F), (formArea.Top + 25.0F));

            // Crea el objeto nave en el punto de la localización del rectangulo
            playerShip = PlayerShip.Instance;
            playerShip.InitValues(formArea,
            new Point((formArea.Width / 2), (formArea.Height - 50)));

            // Creación de las listas
            playerShots = new List<Shot>();
            invaderShots = new List<Shot>();
            invaders = new List<Invader>();

            // Siguiente nivel
            nivel = new Level(invaders);
            nivel.nextWave();
            //nextWave();
        }

        public int LivesLeft { get => livesLeft; set => livesLeft = value; }
        public int NumShots { get => numShots; set => numShots = value; }

        // Draw is fired with each paint event of the main form
        public void Draw(Graphics graphics, int frame, bool gameOver)
        {
            // Fondo negro
            graphics.FillRectangle(Brushes.Black, formArea);

            // Dibuja las estrellas
            stars.Draw(graphics);

            // Para cada invader le pasa frame de animación
            foreach (Invader invader in invaders)
                invader.Draw(graphics, frame);
            playerShip.Draw(graphics);


            foreach (Shot shot in playerShots)
                shot.Draw(graphics);
            foreach (Shot shot in invaderShots)
                shot.Draw(graphics);

            graphics.DrawString(("Score: " + score.ToString()),
                statsFont, Brushes.Yellow, scoreLocation);
            graphics.DrawString(("Lives: " + LivesLeft.ToString()),
                statsFont, Brushes.Yellow, livesLocation);
            graphics.DrawString(("Wave: " + nivel.Wave.ToString()),
                statsFont, Brushes.Yellow, waveLocation);
            if (gameOver)
            {
                nivel = new NullLevel(invaders, graphics, messageFont, formArea);
                nivel.nextWave();
            }

        }

        // Twinkle (animates stars) is called from the form animation timer
        public void Twinkle()
        {
            stars.Twinkle(random);
        }

        public void MovePlayer(Direction direction, bool gameOver)
        {
            if (!gameOver)
            {
                playerShip.Move(direction);
            }
        }

        public void FireShot()
        {
            if (playerShots.Count < NumShots)
            {
                Shot newShot = new Shot(
                    new Point((playerShip.Location.X + (playerShip.image.Width / 2))
                        , playerShip.Location.Y),
                    Direction.Up, formArea);
                playerShots.Add(newShot);
            }
        }

        public void Go()
        {
            if (playerShip.Alive)
            {
                // Check to see if any shots are off screen, to be removed
                List<Shot> deadPlayerShots = new List<Shot>();
                foreach (Shot shot in playerShots)
                {
                    if (!shot.Move())
                        deadPlayerShots.Add(shot);
                }
                foreach (Shot shot in deadPlayerShots)
                    playerShots.Remove(shot);

                List<Shot> deadInvaderShots = new List<Shot>();
                foreach (Shot shot in invaderShots)
                {
                    if (!shot.Move())
                        deadInvaderShots.Add(shot);
                }
                foreach (Shot shot in deadInvaderShots)
                    invaderShots.Remove(shot);

                moveInvaders();
                returnFire();
                checkForCollisions();
                if (invaders.Count < 1)
                {
                    //nextWave();
                    nivel.nextWave();
                }
            }
        }

        public void moveInvaders()
        {
            // if the frame is skipped invaders do not move
            if (currentGameFrame > nivel.FramesSkipped)
            {
                // Check to see if invaders are at edge of screen, 
                // if so change direction
                if (nivel.InvaderDirection == Direction.Right)
                {
                    var edgeInvaders =
                        from invader in invaders
                        where invader.Location.X > (formArea.Width - 100)
                        select invader;
                    if (edgeInvaders.Count() > 0)
                    {
                        nivel.InvaderDirection = Direction.Left;
                        foreach (Invader invader in invaders)
                            invader.Move(Direction.Down);
                    }
                    else
                    {
                        foreach (Invader invader in invaders)
                            invader.Move(Direction.Right);
                    }
                }

                if (nivel.InvaderDirection == Direction.Left)
                {
                    var edgeInvaders =
                        from invader in invaders
                        where invader.Location.X < 100
                        select invader;
                    if (edgeInvaders.Count() > 0)
                    {
                        nivel.InvaderDirection = Direction.Right;
                        foreach (Invader invader in invaders)
                            invader.Move(Direction.Down);
                    }
                    else
                    {
                        foreach (Invader invader in invaders)
                            invader.Move(Direction.Left);
                    }
                }

                // Check to see if invaders have made it to the bottom
                var endInvaders =
                        from invader in invaders
                        where invader.Location.Y > playerShip.Location.Y
                        select invader;
                if (endInvaders.Count() > 0)
                {
                    GameOver(this, null);
                }

                foreach (Invader invader in invaders)
                {
                    invader.Move(nivel.InvaderDirection);
                }

            }
            currentGameFrame++;
            if (currentGameFrame > 6)
                currentGameFrame = 1;
        }

        public void returnFire()
        {
            //// invaders check their location and fire at the player
            if (invaderShots.Count == nivel.Wave)
                return;
            if (random.Next(10) < (10 - nivel.Wave))
                return;

            var invaderColumns =
                from invader in invaders
                group invader by invader.Location.X into columns
                select columns;

            int randomColumnNumber = random.Next(invaderColumns.Count());
            var randomColumn = invaderColumns.ElementAt(randomColumnNumber);

            var invaderRow =
            from invader in randomColumn
            orderby invader.Location.Y descending
            select invader;

            Invader shooter = invaderRow.First();
            Point newShotLocation = new Point
                (shooter.Location.X + (shooter.Area.Width / 2),
            shooter.Location.Y + shooter.Area.Height);

            Shot newShot = new Shot(newShotLocation, Direction.Down,
            formArea);
            invaderShots.Add(newShot);
        }

        public void checkForCollisions()
        {
            // Created seperate lists of dead shots since items can't be
            // removed from a list while enumerating through it
            List<Shot> deadPlayerShots = new List<Shot>();
            List<Shot> deadInvaderShots = new List<Shot>();

            foreach (Shot shot in invaderShots)
            {
                if (playerShip.Area.Contains(shot.Location))
                {
                    deadInvaderShots.Add(shot);
                    LivesLeft--;
                    playerShip.Alive = false;
                    if (LivesLeft == 0)
                        GameOver(this, null);
                    // worth checking for gameOver state here too?
                }
            }

            foreach (Shot shot in playerShots)
            {
                List<Invader> deadInvaders = new List<Invader>();
                foreach (Invader invader in invaders)
                {
                    if (invader.Area.Contains(shot.Location))
                    {
                        deadInvaders.Add(invader);
                        deadInvaderShots.Add(shot);
                        // Add bonus
                        score = invader.AddAditionalScore(score);
                        // Score multiplier based on wave
                        score = score + (1 * nivel.Wave);
                    }
                }
                foreach (Invader invader in deadInvaders)
                {
                    invaders.Remove(invader);

                }
            }
            foreach (Shot shot in deadPlayerShots)
                playerShots.Remove(shot);
            foreach (Shot shot in deadInvaderShots)
                invaderShots.Remove(shot);
        }

        public event EventHandler GameOver;
    }
}
