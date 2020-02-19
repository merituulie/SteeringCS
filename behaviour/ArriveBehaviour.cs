using SteeringCS.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteeringCS.behaviour
{
    class ArriveBehaviour : SteeringBehaviour
    {
        
        public ArriveBehaviour(MovingEntity me) : base(me) {
        }


        public override Vector2D Calculate() {

            Vector2D targetPos = ME.MyWorld.Target.Pos;

            if (targetPos == null) {
                return new Vector2D(0, 0);
            }

            Vector2D toTarget = targetPos.Clone();
            toTarget.Sub(ME.Pos);
            double distance = toTarget.Length();

            if (distance > 0) {
                double speed = distance / 0.3;
                speed = Math.Min(speed, ME.MaxSpeed);
                Vector2D DesiredVelocity = toTarget.Multiply(speed);
                DesiredVelocity.divide(distance);
            
                return DesiredVelocity.Sub(ME.Velocity);
            } else {
                return new Vector2D(0, 0);
            }

        }

    }
}