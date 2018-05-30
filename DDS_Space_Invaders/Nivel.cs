﻿using Lab_3___Invaders.Factory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Lab_3___Invaders
{
    class Nivel
    {
        private const int FINAL_LEVEL = 6;
        private List<Invader> invaders;
        private const int invaderXSpacing = 60;
        private const int invaderYSpacing = 60;
        private int wave = 0;
        private int framesSkipped = 6;
        private Direction invaderDirection;

        public Nivel(List<Invader> invaders)
        {
            this.invaders = invaders;
        }

        public static int FINAL_LEVEL1 => FINAL_LEVEL;
        public int Wave { get => wave; set => wave = value; }
        public int FramesSkipped { get => framesSkipped; set => framesSkipped = value; }
        internal Direction InvaderDirection { get => invaderDirection; set => invaderDirection = value; }

        public void nextWave()
        {
            // Incrementa nivel
            Wave++;

            // Direction dirección derecha
            InvaderDirection = Direction.Right;

            // if the wave is under 7, set frames skipped to 6 - current wave number
            // Mientras menos frames por segundo haya, mas rapido ira
            if (Wave < 7)
            {
                framesSkipped = 6 - Wave;
            }
            else
                framesSkipped = 0;

            int currentInvaderYSpace = 0;

            // Para cada ShipType
            for (int x = 0; x < 5; x++)
            {
                ShipType currentInvaderType = (ShipType)x;
                // Hace el espaciado entre los enemigos en el eje X
                currentInvaderYSpace += invaderYSpacing;
                int currentInvaderXSpace = 0;

                // Numero de columnas de los enemigos en eje Y
                for (int y = 0; y < 5; y++)
                {
                    currentInvaderXSpace += invaderXSpacing;
                    // Encuentra los puntos para dibujar a los enemigos
                    Point newInvaderPoint =
                        new Point(currentInvaderXSpace, currentInvaderYSpace);

                    // Need to add more varied invader score values
                    /*Invader newInvader =
                        new Invader(currentInvaderType, newInvaderPoint, 10);*/
                    #region FactoryMethod
                    CrearInvaders(currentInvaderType, newInvaderPoint, 10);
                    #endregion
                }
            }
        }

        private void CrearInvaders(ShipType currentInvaderType, Point newInvaderPoint, int score)
        {
            Invader enemy = null;
            switch (currentInvaderType)
            {
                case ShipType.Bug:
                    enemy = new Bug(currentInvaderType, newInvaderPoint, 10);
                    break;
                case ShipType.Satellite:
                    enemy = new Satellite(currentInvaderType, newInvaderPoint, 10);
                    break;
                case ShipType.Saucer:
                    enemy = new Saucer(currentInvaderType, newInvaderPoint, 10);
                    break;
                case ShipType.Spaceship:
                    enemy = new Spaceship(currentInvaderType, newInvaderPoint, 10);
                    break;
                case ShipType.Star:
                    enemy = new Lab_3___Invaders.Factory.Star(currentInvaderType, newInvaderPoint, 10);
                    break;
            }
            invaders.Add(enemy);
        }
    }
}
