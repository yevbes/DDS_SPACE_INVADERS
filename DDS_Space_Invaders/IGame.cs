using Invaders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Invaders
{
    interface IGame
    {
        void Draw(Graphics graphics, int frame, bool gameOver);
        void Twinkle();
        void MovePlayer(Direction direction, bool gameOver);
        void FireShot();
        void Go();
        void moveInvaders();
        void returnFire();
        void checkForCollisions();
        int LivesLeft { get; set; }
        int NumShots { get; set; }
    }
}
