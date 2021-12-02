﻿using Syncfusion.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.Helper
{
    public class ToolObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _icon;

        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }


    }
}