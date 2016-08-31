using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.ViewModels
{
    class TestThread : MvxViewModel
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }
    }
}

