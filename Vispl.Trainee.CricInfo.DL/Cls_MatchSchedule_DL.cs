using System;
using System.Collections.Generic;
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
                        string query = "INSERT INTO MatchSchedule (Team1, Team2, MatchDate, TimeZone, Venue, MatchFormat) " +
                                       "VALUES (@Team1, @Team2, @MatchDate, @TimeZone, @Venue, @MatchFormat)";
                        using (SqlCommand cmd = new SqlCommand(query, cnn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Team1", matchSchedule.Team1);
                            cmd.Parameters.AddWithValue("@Team2", matchSchedule.Team2);
                            cmd.Parameters.AddWithValue("@MatchDate", matchSchedule.MatchDate);
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

        public List<Cls_MatchSchedule_VO> GetAllMatchSchedules()
        {
            List<Cls_MatchSchedule_VO> matchSchedules = new List<Cls_MatchSchedule_VO>();

            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = "SELECT Team1, Team2, MatchDate, TimeZone, Venue, MatchFormat FROM MatchSchedule";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cls_MatchSchedule_VO matchSchedule = new Cls_MatchSchedule_VO
                            {
                                Team1 = reader["Team1"].ToString(),
                                Team2 = reader["Team2"].ToString(),
                                MatchDate = Convert.ToDateTime(reader["MatchDate"]),
                                TimeZone = reader["TimeZone"].ToString(),
                                Venue = reader["Venue"].ToString(),
                                MatchFormat = reader["MatchFormat"].ToString()
                            };

                            matchSchedules.Add(matchSchedule);
                        }
                    }
                }
            }

            return matchSchedules;
        }
    }
}
