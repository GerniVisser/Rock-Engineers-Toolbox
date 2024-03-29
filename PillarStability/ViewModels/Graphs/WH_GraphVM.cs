﻿using SharedWpfLibrary.ViewModels;
using PillarStability.Models;
using PillarStability.Services;
using SharedWpfLibrary.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PillarStability.ViewModels.Graphs
{
    public class WH_GraphVM: GraphBaseViewModel
    {
        private PillarModel _pillarModel;
        private Wh_Service _wh_Service;

        public WH_GraphVM(PillarModel pillarModel)
        {
            _pillarModel = pillarModel;
            _wh_Service = new Wh_Service(pillarModel);
        }

        public override void Update()
        {
            if(_pillarModel.PillarStrengthModel is LunderPakalnisModel)
            {
                _wh_Service.PillarStrengthService = new LunderPakalnisService(_pillarModel);
            }
            else
            {
                _wh_Service.PillarStrengthService = new PowerFormulaService(_pillarModel);
            }
            OnPropertyChanged(nameof(GraphLineDesiredFOS));
            OnPropertyChanged(nameof(GraphLineFOS1));
            OnPropertyChanged(nameof(GraphPoint));
            OnPropertyChanged(nameof(GraphPointColor));
            OnPropertyChanged(nameof(FosLabel));
        }

        public string GraphHeader
        {
            get { return "Stress Analysis"; }
        }

        public string xAxisHeader
        {
            get { return "Width / Heigth"; }
        }

        public string yAxisHeader
        {
            get { return "Average Stress"; }
        }

        public List<Coord> GraphLineDesiredFOS
        {
            get { return _wh_Service.graphStable(); }
        }

        public string FosLabel
        {
            get { return "FOS " + _pillarModel.DesiredFOS.ToString(); }
        }

        public List<Coord> GraphLineFOS1
        {
            get { return _wh_Service.graphStableFos1(); }
        }

        public List<Coord> GraphPoint
        {
            get { return _wh_Service.graphPoint(); }
        }

        public Brush GraphPointColor
        {
            get { return _pillarModel.Color; }
        }

    }
}
