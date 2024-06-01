using System;
using Vispl.Trainee.CricInfo.VO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.DL
{
    public class Cls_Player_DL : ICls_Player_DL
    {
        /// <summary>
        /// Represents the connection string.
        /// </summary>
        private readonly string _connectionString;

        public Cls_Player_DL(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Add Player Information Into Database.
        /// </summary>
        /// <param name="player">An object that holds information of a player.</param>
        public bool AddNewPlayer(Cls_Player_VO player)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = "INSERT INTO Players" +
                        "(JerseyNo, Name, DateOfBirth, BirthPlace, PlayerType, IsCaptain, IsSubstitute, Nationality, Team, MatchesPlayed, RunsScored, WicketsTaken, BattingAverage, BowlingAverage, Centuries, HalfCenturies, DebutDate, ICCRanking, Picture)" +
                        " VALUES " +
                        "(@JerseyNo, @Name, @DateOfBirth, @BirthPlace, @PlayerType, @IsCaptain, @IsSubstitute, @Nationality, @Team, @MatchesPlayed, @RunsScored, @WicketsTaken, @BattingAverage, @BowlingAverage, @Centuries, @HalfCenturies, @DebutDate, @ICCRanking, @Picture);";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("JerseyNo", player.JerseyNo);
                        cmd.Parameters.AddWithValue("Name", player.Name);
                        
                        string formattedDate = player.DateOfBirth.ToString("yyyy-MM--dd");
                        /* cmd.Parameters.AddWithValue("@DateOfBirth", formattedDate);*/
                        cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = (object)player.DateOfBirth ?? DBNull.Value;

                        cmd.Parameters.AddWithValue("BirthPlace", player.BirthPlace);
                        cmd.Parameters.AddWithValue("PlayerType", player.PlayerType);
                        cmd.Parameters.AddWithValue("IsCaptain", player.IsCaptain);
                        cmd.Parameters.AddWithValue("IsSubstitute", player.IsSubstitute);
                        cmd.Parameters.AddWithValue("Nationality", player.Nationality);
                        cmd.Parameters.AddWithValue("Team", player.Team);
                        cmd.Parameters.AddWithValue("MatchesPlayed", player.MatchesPlayed);
                        cmd.Parameters.AddWithValue("RunsScored", player.RunsScored);
                        cmd.Parameters.AddWithValue("WicketsTaken", player.WicketsTaken);
                        cmd.Parameters.AddWithValue("BattingAverage", player.BattingAverage);
                        cmd.Parameters.AddWithValue("BowlingAverage", player.BowlingAverage);
                        cmd.Parameters.AddWithValue("Centuries", player.Centuries);
                        cmd.Parameters.AddWithValue("HalfCenturies", player.HalfCenturies);
                       
                        string formatedDate = player.DebutDate.ToString("yyyy--MM--dd");
                        /*cmd.Parameters.AddWithValue("@DebutDate", formatedDate);*/
                        cmd.Parameters.Add("@DebutDate", SqlDbType.DateTime).Value = (object)player.DebutDate ?? DBNull.Value;

                        cmd.Parameters.AddWithValue("ICCRanking", player.ICCRanking);
                        cmd.Parameters.AddWithValue("Picture", player.Picture);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves all players from the database.
        /// </summary>
        public List<Cls_Player_VO> GetAllPlayers()
        {
            List<Cls_Player_VO> players = new List<Cls_Player_VO>();
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = "SELECT * FROM Players";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cls_Player_VO player = new Cls_Player_VO
                            {
                                PlayerID = long.Parse(reader["PlayerID"].ToString()),
                                JerseyNo = int.Parse(reader["JerseyNo"].ToString()),
                                Name = reader["Name"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                BirthPlace = reader["BirthPlace"].ToString(),
                                PlayerType = reader["PlayerType"].ToString(),
                                IsCaptain = bool.Parse(reader["IsCaptain"].ToString()),
                                IsSubstitute = bool.Parse(reader["IsSubstitute"].ToString()),
                                Nationality = reader["Nationality"].ToString(),
                                Team = reader["Team"].ToString(),
                                MatchesPlayed = int.Parse(reader["MatchesPlayed"].ToString()),
                                RunsScored = int.Parse(reader["RunsScored"].ToString()),
                                WicketsTaken = int.Parse(reader["WicketsTaken"].ToString()),
                                BattingAverage = double.Parse(reader["BattingAverage"].ToString()),
                                BowlingAverage = double.Parse(reader["BowlingAverage"].ToString()),
                                Centuries = int.Parse(reader["Centuries"].ToString()),
                                HalfCenturies = int.Parse(reader["HalfCenturies"].ToString()),
                                DebutDate = Convert.ToDateTime(reader["DebutDate"]),
                                ICCRanking = int.Parse(reader["ICCRanking"].ToString()),
                                Picture = reader["Picture"].ToString()
                            };

                            players.Add(player);
                        }
                    }
                }
            }
            return players;
        }
    }
}
