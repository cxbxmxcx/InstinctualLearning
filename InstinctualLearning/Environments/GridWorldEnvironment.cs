﻿namespace InstinctualLearning
{
    public class GridWorldEnvironment : IEnvironment
    {
        int state = 1;
        public int size = 4;

        public int State
        {
            get
            {
                return state;
            }
        }

        public double FinalReward
        {
            get
            {               

                switch (state)
                {
                    case 16:
                        return 1.0;

                    case 12:
                    case 15:
                        return .9;

                    case 14:
                    case 11:
                    case 8:
                        return .8;

                    case 13:
                    case 10:
                    case 7:
                    case 4:
                        return .7;

                    case 9:
                    case 6:
                    case 3:
                        return .6;

                    case 5:
                    case 2:
                        return .5;

                    default:
                        return 0;

                }
            }
        }

        public double ExpectedReward
        {
            get
            {
                switch (state)
                {
                    case 16:
                        return 1.0;

                    case 12:
                    case 15:
                        return .9;

                    case 14:                    
                    case 8:
                        return .8;

                    case 11:
                        return .7;

                    case 13:                    
                    case 4:
                        return .7;

                    case 10:
                    case 7:
                        return .6;

                    case 9:
                    case 3:
                        return .6;

                    case 6:
                        return .5;

                    case 5:
                    case 2:
                        return .55;

                    default:
                        return 0;

                }
            }
        }



        public double Act(double act)
        {    
            switch ((int)act)
            {
                case 1:
                    if (state > 4)
                    {
                        state = state - 4; //moving up;
                    }
                    break;

                case 2:
                    if (state < 16 && (state != 4 || state != 8 || state != 12))
                    {
                        state = state + 1; //moving right
                    }
                    break;

                case 3:
                    if (state < 13)
                    {
                        state = state + 4; // moving down
                    }
                    break;

                case 4:
                    if (state > 1 && (state != 5 || state != 9 || state != 13))
                    {
                        state = state + 1; //moving left
                    }
                    break;

                default:
                    break;
            }
            state = state == 16 ? 16 : state;

            return 0.0;
        }
        
    }
}