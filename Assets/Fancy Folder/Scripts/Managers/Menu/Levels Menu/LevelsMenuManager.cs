using UnityEngine;
using Menu.Managers.SubMenus;
using Menu.Managers.Items;
using System.Collections.Generic;

namespace Menu.Managers {
	public class LevelsMenuManager : MainMenuManager {
        public static List<Matrix> levelMatrices;

        protected override void Start()
        {
            base.Start();
            levelMatrices = new List<Matrix>();

            // L1
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 1, 1 },
                { 1, 1 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(1, 1);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(-1, -1);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 1;

            // L2
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 3, 4, 4 },
                { 2, 4, 4 },
                { 1, 1, 1 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(2, 2);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(-1, -1);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 4;

            // L3
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 3, 4, 4 },
                { 3, 3, 3 },
                { 1, 1, 1 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(2, 2);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(0, 2);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 4;

            // L4
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 1, 1 },
                { 3, 3 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(1, 1);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(2, 3);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 1;

            // L5
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 2, 3, 1 },
                { 2, 3, 1 },
                { 2, 3, 1 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(2, 2);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(-1, -1);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 3;

            // L6
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 2, 2, 2 },
                { 2, 2, 2 },
                { 1, 1, 1 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(2, 2);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(-1, -1);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 4;

            // L7
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 1, 3, 2 },
                { 3, 3, 1 },
                { 2, 1, 3 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(2, 2);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(-1, -1);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 3;

            // L8
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 3, 5, 1, 3 },
                { 1, 6, 3, 2 },
                { 3, 1, 3, 4 },
                { 5, 1, 3, 2 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(3, 3);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(0, 3);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 4;

            // L9
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 3, 7, 2, 8 },
                { 3, 5, 1, 1 },
                { 1, 3, 2, 2 },
                { 3, 4, 2, 2 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(3, 3);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(-1, -1);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 8;

            // L10
            levelMatrices.Add(new Matrix(new int[,]
            {
                { 4, 2, 0, 3 },
                { 5, 2, 3, 2 },
                { 3, 2, 4, 1 },
                { 3, 1, 5, 1 }
            }));
            levelMatrices[levelMatrices.Count - 1].StartLocation = new Vector2(3, 3);
            levelMatrices[levelMatrices.Count - 1].BananaLocation = new Vector2(-1, -1);
            levelMatrices[levelMatrices.Count - 1].EndLocation = new Vector2(0, 0);
            levelMatrices[levelMatrices.Count - 1].EndHeight = 7;
        }

        void OnDisable()
        {
            Animator.SetTrigger(ExitRight);
        }
    }
}