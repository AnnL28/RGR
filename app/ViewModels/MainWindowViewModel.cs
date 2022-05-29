using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using curs.Models;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;

namespace curs.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request, value);
        }

        private ObservableCollection<Game> _games;
        private ObservableCollection<League> _leagues;
        private ObservableCollection<Shot> _shots;
        private ObservableCollection<Statistics> _stats;
        private ObservableCollection<Player> _players;
        private ObservableCollection<Team> _teams;





        public ObservableCollection<Game> Games
        {
            get => _games;
            set => this.RaiseAndSetIfChanged(ref _games, value);
        }
        public ObservableCollection<League> Leagues
        {
            get => _leagues;
            set => this.RaiseAndSetIfChanged(ref _leagues, value);
        }
        public ObservableCollection<Shot> Shots
        {
            get => _shots;
            set => this.RaiseAndSetIfChanged(ref _shots, value);
        }
        public ObservableCollection<Statistics> Stats
        {
            get => _stats;
            set => this.RaiseAndSetIfChanged(ref _stats, value);
        }
        public ObservableCollection<Player> Players
        {
            get => _players;
            set => this.RaiseAndSetIfChanged(ref _players, value);
        }
        public ObservableCollection<Team> Teams
        {
            get => _teams;
            set => this.RaiseAndSetIfChanged(ref _teams, value);
        }

        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }
        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel()
        {
           
            using (var db = new hockeyContext())
            {
                this.Games = new ObservableCollection<Game>(db.Games);
                this.Leagues = new ObservableCollection<League>(db.Leagues);
                this.Players = new ObservableCollection<Player>(db.Players);
                this.Shots = new ObservableCollection<Shot>(db.Shots);
                this.Stats = new ObservableCollection<Statistics>(db.Stats);
                this.Teams = new ObservableCollection<Team>(db.Teams);
                
            }
            Content = new DataViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1"),
                new Request("2")
            };


        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }

        public void DeletePlayer(Player e) => Players.Remove(e);
        public void DeleteLeague(League e) => Leagues.Remove(e);
        public void DeleteGame(Game e) => Games.Remove(e);
        public void DeleteShot(Shot e) => Shots.Remove(e);
        public void DeleteStatistics(Statistics e) => Stats.Remove(e);
        public void DeleteTeam(Team e) => Teams.Remove(e);

        public void CreatePlayer() => Players.Add(new Player() { Number = "new", Position = "new", Name = "new", TeamId = "new" });
        public void CreateLeague() => Leagues.Add(new League() { Name = "new", Region = "new" });
        public void CreateGame() => Games.Add(new Game() { GameN = 1, Date = "new", Time = "new" });
        public void CreateShot() => Shots.Add(new Shot() { Time = "new", ScorerId = "new", Type = "new", Distance = "new", GameId = "new" });
        public void CreateStatistics() => Stats.Add(new Statistics() { GameId = "new", Team1Id = "new", Score_team1 = 0, Assists_team1 = 0, Plus_minus_team1 = 0, Penalties_team1 = 0, Team2Id = "new", Score_team2 = 0, Assists_team2 = 0, Plus_minus_team2 = 0, Penalties_team2 = 0 });
        public void CreateTeam() => Teams.Add(new Team { Name = "new", LeagueId = "new" });

        public void SQLRequestOpen() => Content = new RequestViewModel();
        public void SQLRequestRun()
        {

            using (var db = new hockeyContext())
            {
                ///////////////////////
            }
            Content = new DataViewModel();
        }
    }
}
