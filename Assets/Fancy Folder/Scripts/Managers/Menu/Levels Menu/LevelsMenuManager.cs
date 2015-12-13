using UnityEngine;
using Menu.Managers.SubMenus;
using Menu.Managers.Items;

namespace Menu.Managers {
	public class LevelsMenuManager : MainMenuManager {
        public static Matrix level1matrix;
        public static Matrix level3matrix;
        public static Matrix level2matrix;

        protected override void Start()
        {
            base.Start();
            level1matrix = new Matrix(new int[,]
            {
            { 1, 2 },
            { 1, 1 }
            });
            level1matrix.StartLocation = new Vector2(1, 1);
            level1matrix.BananaLocation = new Vector2(-1, -1);
            level1matrix.EndLocation = new Vector2(0, 0);

            level2matrix = new Matrix(new int[,]
            {
            { 1, 3, 2 },
            { 3, 3, 1 },
            { 2, 1, 3 }
            });
            level2matrix.StartLocation = new Vector2(2, 2);
            level2matrix.BananaLocation = new Vector2(-1, -1);
            level2matrix.EndLocation = new Vector2(0, 0);


            level3matrix = new Matrix(new int[,]
            {
            { 3, 5, 1, 3 },
            { 1, 6, 3, 2 },
            { 3, 1, 3, 4 },
            { 5, 1, 3, 2 }
            });
            level3matrix.StartLocation = new Vector2(3, 3);
            level3matrix.BananaLocation = new Vector2(2, 3);
            level3matrix.EndLocation = new Vector2(0, 0);
        }

        void OnDisable()
        {
            Animator.SetTrigger(ExitRight);
        }
    }
}