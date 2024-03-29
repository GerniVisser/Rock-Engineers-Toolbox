﻿using SharedWpfLibrary.ViewModels;
using Caveability.Commands;
using Caveability.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Caveability.ViewModels
{
    public class CaveabilityViewModel : ViewModelBase
    {
        // Private List to keep track of all Walls 
        // This List is what is quaried when a new CurrentWall is set
        private List<WallViewModel> _wallViewModelList;

        // Current wall and what should be interacted with
        private WallViewModel _currentWallViewModel;
        public WallViewModel CurrentWallViewModel
        {
            get { return _currentWallViewModel; }
            set
            {
                if (_currentWallViewModel == value) return;

                _currentWallViewModel = value;
                OnPropertyChanged(nameof(CurrentWallViewModel));
            }
        }

        private int _tabWallIndex;

        public int TabWallIndex
        {
            get { return _tabWallIndex; }
            set 
            {
                _tabWallIndex = value;
                CurrentWallViewModel = _wallViewModelList[value];
                OnPropertyChanged(nameof(TabWallIndex));
            }
        }

        public CaveabilityViewModel(CaveabilityModel caveabilityModel)
        {
            _wallViewModelList = new List<WallViewModel>
            {
                new WallViewModel(caveabilityModel.Hangwall),
                new WallViewModel(caveabilityModel.Footwall),
                new WallViewModel(caveabilityModel.StopeBack),
                new WallViewModel(caveabilityModel.StrikeEnd)
            };
            TabWallIndex = 0;
        }

    }
}
