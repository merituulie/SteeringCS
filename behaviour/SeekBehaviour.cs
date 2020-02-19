using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behaviour
{
    class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity me) : base(me) {
        }

        public override Vector2D Calculate() {

            Vector2D targetPos = ME.MyWorld.Target.Pos;

            if (targetPos == null) {
                return new Vector2D(0, 0); 
            }

            Vector2D DesiredVelocity = targetPos.Clone();
            DesiredVelocity.Sub(ME.Pos);
            DesiredVelocity.Normalize();
            DesiredVelocity.Multiply(ME.MaxSpeed);

            return DesiredVelocity.Sub(ME.Velocity);
        }

    }
}
