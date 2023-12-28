﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Helpers;

namespace TodoList.Models
{
    public class TodoModel : CommandNotifier
    {
		private string _title;

		public string Title
		{
			get { return _title; }
			set { _title = value;
				OnPropertyChange(nameof(Title)); 
			}
		}


		private bool _isDone;

        public bool IsDone
		{
			get { return _isDone; }
			set { _isDone = value;
				OnPropertyChange(nameof(IsDone));
			}
		}
     
    }
}
