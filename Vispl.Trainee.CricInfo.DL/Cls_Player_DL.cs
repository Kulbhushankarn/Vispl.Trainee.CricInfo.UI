using System;
using Vispl.Trainee.CricInfo.VO;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vispl.Trainee.CricInfo.DL
{
    public class Cls_Player_DL : ICls_Player_DL
    {
        /// <summary>
        /// Represents the connection String
        /// </summary>
        private readonly string _connectionString;

        public Cls_Player_DL(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Add Player Information Into Database
        /// </summary>
        /// <param name="player"> An Object that holds information of an player</param>
        public bool AddNewPlayer(Cls_Player_VO player)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(_connectionString))
                {
                    cnn.Open();
                    string query = "INSERT INTO Players" +
                        "(Name,DateOfBirth,Nationality,Role,BattingStyle,isAllRounder,BowlingStyle,ProfilePictureURL,TeamPlayingFor)" +
                        " Values" +
                        " (@name,@dob,@Nationality,@Role,@BattingStyle,@isAllRounder,@BowlingStyle,@PicUrl,@TeamPlayingFor);";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.Parameters.AddWithValue("name", player.Name);
                        cmd.Parameters.AddWithValue("dob", player.DOB.Date);
                        cmd.Parameters.AddWithValue("Nationality", player.Nationality);
                        cmd.Parameters.AddWithValue("Role", player.Role);
                        cmd.Parameters.AddWithValue("BattingStyle", player.BattingStyle);
                        cmd.Parameters.AddWithValue("BowlingStyle", player.BowlingStyle);
                        cmd.Parameters.AddWithValue("TeamPlayingFor", player.TeamPlayingFor);
                        cmd.Parameters.AddWithValue("isAllRounder", player.isAllRounder ? 0 : 1);
                        cmd.Parameters.AddWithValue("PicUrl", "");

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

        public List<Cls_Player_VO> GetAllPlayers()
        {
            List<Cls_Player_VO> players;
            using (SqlConnection cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                string query = "SELECT * FROM PLAYERS";
                using (SqlCommand cmd = new SqlCommand(query, cnn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        players = new List<Cls_Player_VO>();
                        while (reader.Read())
                        {
                            Cls_Player_VO player = new Cls_Player_VO();
                            player.Name = reader["Name"] as string;
                            player.PlayerID = long.Parse(Convert.ToInt32(reader["PlayerID"]).ToString());
                            player.BattingStyle = reader["BattingStyle"] as string;
                            player.BowlingStyle = reader["BowlingStyle"] as string;
                            player.DOB = Convert.ToDateTime(reader["DateOfBirth"]);
                            player.TeamPlayingFor = (reader["TeamPlayingFor"]) as string;
                            players.Add(player);
                        }
                    }

                }
            }
            return players;
        }
    }
}
