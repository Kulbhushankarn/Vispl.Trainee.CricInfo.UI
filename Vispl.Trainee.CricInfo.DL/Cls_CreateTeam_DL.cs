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
                    using (SqlTransaction transaction = cnn.BeginTransaction())
                    {
                        try
                        {
                            // Insert into Teams table
                            string query = "INSERT INTO TeamCreate (TeamName, TeamShortName, TeamCaptain, TeamWicketKeeper, TeamViceCaptain) " +
                                           "VALUES (@TeamName, @TeamShortName, @TeamCaptain, @TeamWicketKeeper, @TeamViceCaptain); " +
                                           "SELECT SCOPE_IDENTITY();";
                            long teamId;
                            using (SqlCommand cmd = new SqlCommand(query, cnn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TeamName", team.TeamName);
                                cmd.Parameters.AddWithValue("@TeamShortName", team.TeamShortName);
                                cmd.Parameters.AddWithValue("@TeamCaptain", GetPlayerIdByName(cnn, transaction, team.TeamCaptain));
                                cmd.Parameters.AddWithValue("@TeamWicketKeeper", GetPlayerIdByName(cnn, transaction, team.TeamWicketKeeper));
                                cmd.Parameters.AddWithValue("@TeamViceCaptain", GetPlayerIdByName(cnn, transaction, team.TeamViceCaptain));

                                teamId = Convert.ToInt64(cmd.ExecuteScalar());
                            }

                            // Insert into TeamPlayers table
                            foreach (var playerName in team.TeamPlayer)
                            {
                                string playerQuery = "INSERT INTO TeamPlayers (TeamID, PlayerID) VALUES (@TeamID, @PlayerID);";
                                using (SqlCommand playerCmd = new SqlCommand(playerQuery, cnn, transaction))
                                {
                                    playerCmd.Parameters.AddWithValue("@TeamID", teamId);
                                    playerCmd.Parameters.AddWithValue("@PlayerID", GetPlayerIdByName(cnn, transaction, playerName));
                                    playerCmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Error adding team: " + ex.Message);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        private long GetPlayerIdByName(SqlConnection cnn, SqlTransaction transaction, string playerName)
        {
            string query = "SELECT PlayerID FROM Players WHERE Name = @Name";
            using (SqlCommand cmd = new SqlCommand(query, cnn, transaction))
            {
                cmd.Parameters.AddWithValue("@Name", playerName);
                return Convert.ToInt64(cmd.ExecuteScalar());
            }
        }


        public List<Cls_TeamPlayer_VO> GetAllTeams()
        {
            List<Cls_TeamPlayer_VO> teams = new List<Cls_TeamPlayer_VO>();
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = "SELECT t.TeamID, t.TeamName, t.TeamShortName, p1.Name AS TeamCaptain, p2.Name AS TeamWicketKeeper, p3.Name AS TeamViceCaptain " +
                               "FROM TeamCreate t " +
                               "JOIN Players p1 ON t.TeamCaptain = p1.PlayerID " +
                               "JOIN Players p2 ON t.TeamWicketKeeper = p2.PlayerID " +
                               "JOIN Players p3 ON t.TeamViceCaptain = p3.PlayerID";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cls_TeamPlayer_VO team = new Cls_TeamPlayer_VO
                            {
                                TeamID = Convert.ToInt64(reader["TeamID"]),
                                TeamName = reader["TeamName"].ToString(),
                                TeamShortName = reader["TeamShortName"].ToString(),
                                TeamCaptain = reader["TeamCaptain"].ToString(),
                                TeamWicketKeeper = reader["TeamWicketKeeper"].ToString(),
                                TeamViceCaptain = reader["TeamViceCaptain"].ToString(),
                            };
                            team.TeamPlayer = GetTeamPlayersByTeamId(cnn, team.TeamID);
                            teams.Add(team);
                        }
                    }
                }
            }
            return teams;
        }

        private List<string> GetTeamPlayersByTeamId(SqlConnection cnn, long teamId)
        {
            List<string> players = new List<string>();
            string query = "SELECT p.Name FROM TeamPlayers tp " +
                           "JOIN Players p ON tp.PlayerID = p.PlayerID " +
                           "WHERE tp.TeamID = @TeamID";
            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@TeamID", teamId);
                using (SqlDataReader reader = cmd.ExecuteReader())  
                {
                    while (reader.Read())
                    {
                        players.Add(reader["Name"].ToString());
                    }
                }
            }
            return players;
        }

        
        private List<string> GetTeamPlayers(SqlConnection cnn, string teamName)
        {
            List<string> players = new List<string>();
            string query = "SELECT p.Name FROM TeamPlayers tp " +
                           "JOIN Players p ON tp.PlayerID = p.PlayerID " +
                           "JOIN Teams t ON tp.TeamID = t.TeamID " +
                           "WHERE t.TeamName = @TeamName";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@TeamName", teamName);

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                players.Add(reader["Name"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception here
                        // Log or throw the exception as needed
                    }
                }
            }

            return players;
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
