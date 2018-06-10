using Invaders.Patterns.Gamma_patterns.Strategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Invaders
{
    public partial class Form1 : Form
    {
        public int Frame = 0;
        // The form keeps a reference to a single Game object
        private Game game;
        public Rectangle FormArea { get { return this.ClientRectangle; } }
        Random random = new Random();
        private Graphics g;
        List<Keys> keysPressed = new List<Keys>();

        private bool gameOver;

        public Form1()
        {
            InitializeComponent();
            Frame = 0;
            game = new Game(random, FormArea);
            gameOver = false;
            game.GameOver += new EventHandler(game_GameOver);
            animationTimer.Start();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            if (Frame < 3)
                Frame++;
            else
                Frame = 0;
            game.Twinkle();
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            g = graphics;
            game.Draw(graphics, Frame, gameOver);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Q)
                Application.Exit();
            if (e.KeyCode == Keys.S)
            {
                // code to reset the game
                gameOver = false;
                game = new Game(random, FormArea);
                game.GameOver += new EventHandler(game_GameOver);
                gameTimer.Start();
                return;
            }
            if (e.KeyCode == Keys.Space)
                game.FireShot();
            if (keysPressed.Contains(e.KeyCode))
                keysPressed.Remove(e.KeyCode);
            keysPressed.Add(e.KeyCode);

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (keysPressed.Contains(e.KeyCode))
                keysPressed.Remove(e.KeyCode);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            game.Go();
            foreach (Keys key in keysPressed)
            {
                if (key == Keys.Left)
                {
                    game.MovePlayer(Direction.Left, gameOver);
                    return;
                }
                else if (key == Keys.Right)
                {
                    game.MovePlayer(Direction.Right, gameOver);
                    return;
                }
            }
            UseStrategy();
        }

        private void UseStrategy()
        {
            Contexto context = null;
            switch (game.LivesLeft)
            {
                case 0:
                    context = new Contexto(new EstrategiaMuere());
                    game.NumShots = context.ExecuteStrategy();
                    break;
                case 1:
                    context = new Contexto(new EstrategiaDispara5());
                    game.NumShots = context.ExecuteStrategy();
                    break;
                case 2:
                    context = new Contexto(new EstrategiaDispara4());
                    game.NumShots = context.ExecuteStrategy();
                    break;
                case 3:
                    context = new Contexto(new EstrategiaDispara3());
                    game.NumShots = context.ExecuteStrategy();
                    break;
            }
        }

        private void game_GameOver(object sender, EventArgs e)
        {
            gameTimer.Stop();
            gameOver = true;
            Invalidate();
        }
    }
}
