using Database;
using Microsoft.VisualBasic;
using System;

namespace PracticingUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; } = "Welcome to Avalonia!";
        private readonly AppDbContext _db;
        public MainWindowViewModel(AppDbContext db)
        {
            _db = db;
            var canConnect = db.Database.CanConnect();
            Greeting = canConnect ? "Connected!" : "Failed to connect!";
        }
    }
}
