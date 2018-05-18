using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab_3___Invaders
{
    public partial class Form1 : Form
    {
        public int Frame = 0;
        // The form keeps a reference to a single Game object
        private Game game;
        public Rectangle FormArea { get { return this.ClientRectangle; } }
        Random random = new Random();
        private Rectangle r;
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
        }

        private void game_GameOver(object sender, EventArgs e)
        {
            gameTimer.Stop();
            gameOver = true;
            Invalidate();
        }
        Timer t;
        int move_x = 0;
        int move_y = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            r = new Rectangle(10, 10, 35, 35);
            g = this.CreateGraphics();
            t = new Timer();
            t.Interval = 10;
            t.Tick += new EventHandler(t_Ticks_Two);
            t.Start();
        }

        private void t_Ticks_Two(object sender, EventArgs e)
        {
            g.DrawRectangle(new Pen(Brushes.Cornsilk, 6), r);
            r.Y += move_y;
        }
    }
}
