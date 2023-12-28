using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Helpers;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        public string Title { get { return $"Todo {TodoModelList.Count(s => !s.IsDone)} Completed: {TodoModelList.Count(s=>s.IsDone)}"; } }
		private ObservableCollection<TodoModel> _todoModelList =new ObservableCollection<TodoModel>();

		public ObservableCollection<TodoModel> TodoModelList
		{
			get { return _todoModelList; }
			set { _todoModelList = value; }
		}

		private string _newtodo;


        public string Newtodo
        {
			get { return _newtodo; }
			set { _newtodo = value;
                OnPropertyChange(nameof(Newtodo));
            }
            
		}

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand AddCommand { get; set; }

        internal void AddTodo()
        {
            if (string.IsNullOrEmpty(Newtodo)) return;

            TodoModel model = new TodoModel() { Title = Newtodo };
            model.PropertyChanged += Todo_PropertyChnages;
            TodoModelList.Add(model);
            Newtodo = String.Empty;
            OnPropertyChange(nameof(Title));
        }

        private void Todo_PropertyChnages(object? sender, PropertyChangedEventArgs e)
        {
            // checking that which property has changed.. 
            if(e.PropertyName=="IsDone")
                OnPropertyChange(nameof(Title));
            
        }

        public TodoViewModel()
        {
            AddCommand = new AddCommand(this);
            //TodoModelList.Add(new TodoModel() { IsDone = false, Title = "first title" });
            //TodoModelList.Add(new TodoModel() { IsDone = true, Title = "Second title" });
        }
    }
}
