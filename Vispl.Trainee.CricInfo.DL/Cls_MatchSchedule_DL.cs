using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.DL
{
    public class Cls_MatchSchedule_DL
    {
        private readonly string _connectionString;

        public Cls_MatchSchedule_DL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddMatchSchedule(Cls_MatchSchedule_VO matchSchedule)
        {
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                using (SqlTransaction transaction = cnn.BeginTransaction())
                {
                    try
                    {
                        string query = "INSERT INTO MatchSchedule (Team1ID, Team2ID, MatchDate, TimeZone, Venue, MatchFormat) " +
                                       "VALUES (@Team1ID, @Team2ID, @MatchDate, @TimeZone, @Venue, @MatchFormat)";
                        using (SqlCommand cmd = new SqlCommand(query, cnn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Team1ID", matchSchedule.Team1ID);
                            cmd.Parameters.AddWithValue("@Team2ID", matchSchedule.Team2ID);

                            if (matchSchedule.MatchDate.HasValue)
                            {
                                cmd.Parameters.AddWithValue("@MatchDate", matchSchedule.MatchDate.Value);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@MatchDate", DBNull.Value);
                            }

                            cmd.Parameters.AddWithValue("@TimeZone", matchSchedule.TimeZone);
                            cmd.Parameters.AddWithValue("@Venue", matchSchedule.Venue);
                            cmd.Parameters.AddWithValue("@MatchFormat", matchSchedule.MatchFormat);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error adding match schedule: " + ex.Message);
                    }
                }
            }
        }

        public List<Cls_MatchSchedule_VO> GetAllMatchSchedulesWithNames()
        {
            List<Cls_MatchSchedule_VO> matchSchedules = new List<Cls_MatchSchedule_VO>();

            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = @"SELECT ms.Team1ID, ms.Team2ID, ms.MatchDate, ms.TimeZone, ms.Venue, ms.MatchFormat,
                         t1.TeamName AS Team1Name, t2.TeamName AS Team2Name, s.VenueName
                         FROM MatchSchedule ms
                         INNER JOIN TeamCreate t1 ON ms.Team1ID = t1.TeamID
                         INNER JOIN TeamCreate t2 ON ms.Team2ID = t2.TeamID
                         INNER JOIN Stadium s ON ms.Venue = s.VenueID";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cls_MatchSchedule_VO matchSchedule = new Cls_MatchSchedule_VO
                            {
                                Team1ID = reader.GetInt64(reader.GetOrdinal("Team1ID")),
                                Team2ID = reader.GetInt64(reader.GetOrdinal("Team2ID")),
                                MatchDate = reader.IsDBNull(reader.GetOrdinal("MatchDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("MatchDate")),
                                TimeZone = reader.IsDBNull(reader.GetOrdinal("TimeZone")) ? null : reader.GetString(reader.GetOrdinal("TimeZone")),
                                Venue = reader.GetInt64(reader.GetOrdinal("Venue")),
                                MatchFormat = reader.IsDBNull(reader.GetOrdinal("MatchFormat")) ? null : reader.GetString(reader.GetOrdinal("MatchFormat")),
                                Team1Name = reader.IsDBNull(reader.GetOrdinal("Team1Name")) ? null : reader.GetString(reader.GetOrdinal("Team1Name")),
                                Team2Name = reader.IsDBNull(reader.GetOrdinal("Team2Name")) ? null : reader.GetString(reader.GetOrdinal("Team2Name")),
                                VenueName = reader.IsDBNull(reader.GetOrdinal("VenueName")) ? null : reader.GetString(reader.GetOrdinal("VenueName"))
                            };

                            matchSchedules.Add(matchSchedule);
                        }
                    }
                }
            }

            return matchSchedules;
        }


        public List<KeyValuePair<long, string>> GetTeams()
        {
            List<KeyValuePair<long, string>> teams = new List<KeyValuePair<long, string>>();

            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = "SELECT TeamID, TeamName FROM TeamCreate";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teams.Add(new KeyValuePair<long, string>((long)reader["TeamID"], reader["TeamName"].ToString()));
                        }
                    }
                }
            }

            return teams;
        }

        public List<KeyValuePair<long, string>> GetVenues()
        {
            List<KeyValuePair<long, string>> venues = new List<KeyValuePair<long, string>>();

            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = "SELECT VenueID, VenueName FROM Stadium";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            venues.Add(new KeyValuePair<long, string>((long)reader["VenueID"], reader["VenueName"].ToString()));
                        }
                    }
                }
            }

            return venues;
        }
    }
}
