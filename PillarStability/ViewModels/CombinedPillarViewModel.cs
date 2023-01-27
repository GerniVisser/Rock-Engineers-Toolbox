﻿using SharedWpfLibrary.ViewModels;
using PillarStability.DataObjects;
using PillarStability.Models;
using PillarStability.Services;
using SharedWpfLibrary.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace PillarStability.ViewModels
{
    public class CombinedPillarViewModel : ViewModelBase
    {
        private ObservableCollection<PillarModel> _pillarListModel;
        private Wh_Service _whService;
        private int _selectedFormulaIndex;
        private PillarModel _currentModel;

        public CombinedPillarViewModel(ObservableCollection<PillarModel> pillarListModel)
        {
            _pillarListModel = pillarListModel;
            _currentModel = _pillarListModel[0];
            _whService = new Wh_Service(_currentModel);
            _selectedPillarIndex = -1;
            setFormulaViewModel();
        }

        public ObservableCollection<PillarModel> GraphPointData
        {
            get { return _pillarListModel; }
        }

        public List<Coord> GraphLineStable
        {
            get { return _whService.graphStable(); }
        }

        public int SelectedFormulaIndex
        {
            get { return _selectedFormulaIndex; }
            set
            {
                _selectedFormulaIndex = value;
                setFormulaViewModel();
            }
        }

        private int _selectedPillarIndex;

        public int SelectedPillarIndex
        {
            get { return _selectedPillarIndex; }
            set 
            { 
                _selectedPillarIndex = value;
                OnPropertyChanged(nameof(SelectedPillarIndex));
            }
        }


        public List<string> FormulaDataSource
        {
            get
            {
                return PillarStrengthOptions.Options;
            }
        }

        private void setFormulaViewModel()
        {

            switch (SelectedFormulaIndex)
            {
                case 0:
                    {
                        _currentModel.PillarStrengthModel = new LunderPakalnisModel();
                        _whService.PillarStrengthService = new LunderPakalnisService(_currentModel);
                        break;
                    }
                case 1:
                    {
                        _currentModel.PillarStrengthModel = new PowerFormulaModel(0.46f, 0.66f);
                        _whService.PillarStrengthService = new PowerFormulaService(_currentModel);
                        break;
                    }
                case 2:
                    {
                        _currentModel.PillarStrengthModel = new PowerFormulaModel(0.5f, 0.75f);
                        _whService.PillarStrengthService = new PowerFormulaService(_currentModel);
                        break;
                    }
                case 3:
                    {
                        _currentModel.PillarStrengthModel = new PowerFormulaModel(0.5f, 0.70f);
                        _whService.PillarStrengthService = new PowerFormulaService(_currentModel);
                        break;
                    }
                case 4:
                    {
                        _currentModel.PillarStrengthModel = new PowerFormulaModel(0.76f, 0.36f);
                        _whService.PillarStrengthService = new PowerFormulaService(_currentModel);
                        break;
                    }
                case 5:
                    {
                        _currentModel.PillarStrengthModel = new PowerFormulaModel(0.67f, 0.32f);
                        _whService.PillarStrengthService = new PowerFormulaService(_currentModel);
                        break;
                    }

                default:
                    {
                        _currentModel.PillarStrengthModel = new PowerFormulaModel(0.67f, 0.32f);
                        _whService.PillarStrengthService = new PowerFormulaService(_currentModel);
                        break;
                    }
                    
            }
            OnPropertyChanged(nameof(GraphLineStable));
        }
    }
}
