//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TurnBasedRPG
//{
//    public class Enemy
//    {
//        private BaseState currentState;

//        public bool IsGrounded;
//        public float Speed;
//        public float VerticalSpeed;
        
//        public void ChangeState(BaseState nextState)
//        {
//            currentState?.End();

//            currentState = nextState;

//            currentState?.Start(this);
//        }
//    }

//    public abstract class BaseState
//    {
//        protected Enemy enemy;

//        public virtual void Start(Enemy enemy)
//        {
//            this.enemy = enemy;
//        }

//        public virtual void End()
//        {

//        }

//        public abstract void Update();
//        public abstract void CheckTransition();
//    }

//    public class Stay : BaseState
//    {
//        public override void CheckTransition()
//        {
//            if (enemy.Speed > 0.0f)
//            {
//                enemy.ChangeState(new Walk());
//            }
//            else if (!enemy.IsGrounded)
//            {
//                enemy.ChangeState(new Fall());
//            }
//            else if(enemy.VerticalSpeed > 0.0f)
//            {
//                enemy.ChangeState(new Jump());
//            }
//        }

//        public override void Update()
//        {

//        }
//    }

//    public class Walk : BaseState
//    {
//        public override void CheckTransition()
//        {
//            if(Math.Abs(enemy.Speed - 0.0f) < 0.001f)
//            {
//                enemy.ChangeState(new Stay());
//            }
//            else if (!enemy.IsGrounded)
//            {
//                enemy.ChangeState(new Fall());
//            }
//            else if (enemy.VerticalSpeed > 0.0f)
//            {
//                enemy.ChangeState(new Jump());
//            }
//        }

//        public override void Update()
//        {

//        }
//    }

//    public class Fall : BaseState
//    {
//        public override void CheckTransition()
//        {
//            if(enemy.IsGrounded)
//            {
//                enemy.ChangeState(new Stay());
//            }
//        }

//        public override void Update()
//        {

//        }
//    }

//    public class Jump : BaseState
//    {
//        public override void CheckTransition()
//        {
//            if(Math.Abs(enemy.VerticalSpeed) < 0.01f)
//            {
//                enemy.ChangeState(new Fall());
//            }
//        }

//        public override void Update()
//        {

//        }
//    }
//}
