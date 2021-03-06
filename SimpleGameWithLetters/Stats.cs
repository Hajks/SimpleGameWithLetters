﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameWithLetters
{
    class Stats
    {
        public int Total = 0;
        public int Missed = 0;
        public int Correct = 0;
        public int Accuracy = 0;

        //After clicking button correct/notcorrect updating statistics.
        public void Update(bool correctKey)
        {
            Total++;
            
            if (!correctKey)
            {
                Missed++;
            }
            else
            {
                Correct++;
            }
            Accuracy = 100* Correct / Total ;
        }
        public void Restart()
        {
            Total = 0;
            Missed = 0;
            Correct = 0;
            Accuracy = 0;
        }

    }
}
