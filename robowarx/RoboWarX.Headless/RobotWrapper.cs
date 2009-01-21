using System;
using System.Collections.Generic;
using System.Text;
using RoboWarX.Arena;
using RoboWarX.FileFormats;

namespace RoboWarX.Headless
{
    // Control for displaying the robot status area and controls
    public class RobotWrapper
    {
        private Robot robot_;

        public RobotWrapper(Robot robot)
        {
            this.robot_ = robot;
        }

        public Robot robot
        {
            get { return robot_; }
            set { robot_ = value;}
        }

        // Called based on seconds per update value
        public override string ToString()
        {
            if (robot_ == null)
            {
                return "---";
            }
            else
            {
                if (robot.alive)
                    return String.Format(HeadlessArena.OUTPUT_STRING, 
                        robot.name, robot.number, robot_.energy, robot_.damage,
                        robot.x, robot.y, robot.team, robot);
                else
                    return String.Format("{0}: killed by {1} at time {2}", robot.name,
                        robot.killer == null ? "** Suicide ***" : robot.killer.name,
                        robot.deathTime.ToString());
            }

        }
    }
}
