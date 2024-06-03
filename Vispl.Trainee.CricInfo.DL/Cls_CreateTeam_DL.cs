using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.DL
{
    public class Cls_CreateTeam_DL : ICls_CreateTeam_DL
    {
        private readonly string _connectionString;

        public Cls_CreateTeam_DL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AddTeam(Cls_TeamPlayer_VO team)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = "INSERT INTO TeamCreate" +
                                   "(TeamName, TeamShortName, TeamPlayer, TeamCaptain, TeamWicketKeeper, TeamViceCaptain)" +
                                   "VALUES" +
                                   "(@TeamName, @TeamShortName, @TeamPlayer, @TeamCaptain, @TeamWicketKeeper, @TeamViceCaptain);";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@TeamName", team.TeamName);
                        cmd.Parameters.AddWithValue("@TeamShortName", team.TeamShortName);
                        cmd.Parameters.AddWithValue("@TeamPlayer", string.Join(",", team.TeamPlayer)); // Convert List<long> to comma-separated string
                        cmd.Parameters.AddWithValue("@TeamCaptain", team.TeamCaptain);
                        cmd.Parameters.AddWithValue("@TeamWicketKeeper", team.TeamWicketKeeper);
                        cmd.Parameters.AddWithValue("@TeamViceCaptain", team.TeamViceCaptain);

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

        public List<Cls_TeamPlayer_VO> GetAllTeams()
        {
            List<Cls_TeamPlayer_VO> teams = new List<Cls_TeamPlayer_VO>();
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = "SELECT * FROM TeamCreate";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cls_TeamPlayer_VO team = new Cls_TeamPlayer_VO
                            {
                                TeamName = reader["TeamName"].ToString(),
                                TeamShortName = reader["TeamShortName"].ToString(),
                                TeamPlayer = reader["TeamPlayer"].ToString().Split(',').Select(long.Parse).ToList(), // Convert comma-separated string to List<long>
                                TeamCaptain = (long)reader["TeamCaptain"],
                                TeamWicketKeeper = (long)reader["TeamWicketKeeper"],
                                TeamViceCaptain = (long)reader["TeamViceCaptain"]
                            };
                            teams.Add(team);
                        }
                    }
                }
            }
            return teams;
        }

        public List<string> GetPlayerNames()
        {
            List<string> playerNames = new List<string>();
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = "SELECT Name FROM Players";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            playerNames.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            return playerNames;
        }
    }
}
