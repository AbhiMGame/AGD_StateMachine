﻿using StatePattern.Main;
using StatePattern.StateMachine;

namespace StatePattern.Enemy
{
    public class CloningState<T> : IState where T : EnemyController
    {
        public EnemyController Owner { get; set; }
        private GenericStateMachine<T> stateMachine;

        public CloningState(GenericStateMachine<T> stateMachine) => this.stateMachine = stateMachine;

        public void OnStateEnter()
        {
            CreateAClone();
            CreateAClone();
        }

        public void Update() { }

        public void OnStateExit() { }

        private void CreateAClone()
        {
            CloneController clonedRobot = GameService.Instance.EnemyService.CreateEnemy(Owner.Data) as CloneController;
            clonedRobot.SetCloneCount((Owner as CloneController).CloneCountLeft - 1);
            clonedRobot.Teleport();
            clonedRobot.SetDefaultColor(EnemyColorType.Clone);
            clonedRobot.ChangeColor(EnemyColorType.Clone);
            GameService.Instance.EnemyService.AddEnemy(clonedRobot);
        }
    }
}