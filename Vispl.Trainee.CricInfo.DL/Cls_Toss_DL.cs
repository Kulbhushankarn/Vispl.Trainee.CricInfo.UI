using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Vispl.Trainee.CricInfo.VO;

namespace Vispl.Trainee.CricInfo.DL
{
    public class Cls_Toss_DL 
    {
        private readonly string _connectionString;

        public Cls_Toss_DL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool AddToss(Cls_Toss_VO toss)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = "INSERT INTO Toss (MatchID, TossWonByWhichTeamID, TossDecision) VALUES (@MatchID, @TossWonByWhichTeamID, @TossDecision)";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("@MatchID", toss.MatchID);
                        cmd.Parameters.AddWithValue("@TossWonByWhichTeamID", toss.TossWonByWhichTeamID);
                        cmd.Parameters.AddWithValue("@TossDecision", toss.TossDecision.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
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
    }
}
