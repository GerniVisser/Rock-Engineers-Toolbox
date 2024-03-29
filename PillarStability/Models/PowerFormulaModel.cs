﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarStability.Models
{
    public class PowerFormulaModel : PillarStrengthModel
    {
        public float Alpha;
        public float Beta;
        public float K;
        public float StdK;
        public float StdWidth;
        public float StdHeight;
        public float StdLength;

        public PowerFormulaModel()
        {
            Alpha = 0.5f;
            Beta = 0.5f;
            K = 0.5f;
            StdK = 0.5f;
            StdWidth = 0.5f;
            StdHeight = 0.5f;
            StdLength = 0.5f;
        }

        public PowerFormulaModel(float alpha, float beta, float kappa = 70f)
        {
            Alpha = alpha;
            Beta = beta;
            K = kappa;
            StdK = 0.5f;
            StdWidth = 0.5f;
            StdHeight = 0.1f;
            StdLength = 0.5f;
        }
    }
}
