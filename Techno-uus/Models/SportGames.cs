using System.ComponentModel.DataAnnotations;

namespace Techno_uus.Models
{
    public class SportGames
    {
        [Key] 
        public int GameId { get; set; }
        public string SportName { get; set; }
        public string FirstTeamName { get; set; }
        public string FirstTeamPlayers { get; set; }
        public string pupilGoalie { get; set; }
        public string pupilDefense { get; set; }
        public string pupilOffence { get; set; }
        public string SecondTeamName { get; set; }
        public string GameResult { get; set; }
        public string  HalfTimeScore { get; set; }
        public string SecondHalfTimeScore { get; set; } 
        public string  MatchEndScore { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime HalfTime { get; set; }
        public GameStatus MatchStatus { get; set; }

        public enum GameStatus
        {
            Võit,
            Viik,
            Kaotus
        }
    }
}
