using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace VSPMMS_Chart
{
    public class SQL
    {
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-V1I9QML\SQLEXPRESS;Initial Catalog=GroupHistoryDB;Integrated Security=True");
        //SqlConnection con =   new SqlConnection(@"Data Source=DESKTOP-U33ABQK\SQLEXPRESS2016;Initial Catalog=GroupHistoryDB;Integrated Security=True");
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U33ABQK\SQLEXPRESS2016;Initial Catalog=GroupHistoryDB;USER ID=sa;Password=No123!@#");
        
        public bool SQL_Connected;

        protected SQL()
        {

        }

        private static SQL _instance;

        public static SQL Instance()
        {
            if (_instance == null)
            {
                _instance = new SQL();
            }
            return _instance;
        }
        
        public void TestConnection()
        {
            try
            {
                con.Open();
                SQL_Connected = true;
                con.Close();
            }
            catch(Exception ex)
            {             
                SQL_Connected = false;
            }
        }

        public DataTable dt_Speed_Printing = new DataTable();
        public DataTable dt_Speed_Diecut = new DataTable();
        public DataTable dt_Speed_Gluing = new DataTable();
        public DataTable dt_Speed_GMCSCL = new DataTable();
        public void Quey_Chart_Printing(DateTime start, DateTime end)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "select DateAdd(minute, 5 * (DateDiff(minute, 0, [TriggerTime]) / 5), 0) as Datetime, " +
                             "avg(cola_P601) as P601, avg(cola_P604) as P604, avg(cola_P605) as P605, avg(cola_P5M) as P5M " +
                             "FROM [GroupHistoryDB].[dbo].[DIV_SPEED_HISTRECORD] where TriggerTime >= @Start and TriggerTime <= @End " +
                             "GROUP BY(DateDiff(minute, 0, [TriggerTime]) / 5) " +
                             "ORDER BY Datetime";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Start", start);
                    cmd.Parameters.AddWithValue("End", end);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt_Speed_Printing.Clear();
                    da.Fill(dt_Speed_Printing);
                }
                con.Close();
            }
        }
        public void Quey_Chart_Diecut(DateTime start, DateTime end)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "select DateAdd(minute, 5 * (DateDiff(minute, 0, [TriggerTime]) / 5), 0) as Datetime, " +
                             "avg(cola_BTD2) as BTD2, avg(cola_BTD3) as BTD3, avg(cola_BTD4) as BTD4, avg(cola_BTD5) as BTD5 " +
                             "FROM [GroupHistoryDB].[dbo].[DIV_SPEED_HISTRECORD] where TriggerTime >= @Start and TriggerTime <= @End " +
                             "GROUP BY(DateDiff(minute, 0, [TriggerTime]) / 5) " +
                             "ORDER BY Datetime";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Start", start);
                    cmd.Parameters.AddWithValue("End", end);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt_Speed_Diecut.Clear();
                    da.Fill(dt_Speed_Diecut);
                }
                con.Close();
            }
        }
        public void Quey_Chart_Gluing(DateTime start, DateTime end)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "select DateAdd(minute, 5 * (DateDiff(minute, 0, [TriggerTime]) / 5), 0) as Datetime, " +
                             "avg(cola_D650) as D650, avg(cola_D750) as D750, avg(cola_D1000) as D1000, avg(cola_D1100) as D1100 " +
                             "FROM [GroupHistoryDB].[dbo].[DIV_SPEED_HISTRECORD] where TriggerTime >= @Start and TriggerTime <= @End " +
                             "GROUP BY(DateDiff(minute, 0, [TriggerTime]) / 5) " +
                             "ORDER BY Datetime";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Start", start);
                    cmd.Parameters.AddWithValue("End", end);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt_Speed_Gluing.Clear();
                    da.Fill(dt_Speed_Gluing);
                }
                con.Close();
            }
        }
        public void Quey_Chart_GMCSCL(DateTime start, DateTime end)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "select DateAdd(minute, 5 * (DateDiff(minute, 0, [TriggerTime]) / 5), 0) as Datetime, " +
                             "avg(cola_GMC1) as GMC1, avg(cola_GMC2) as GMC2, avg(cola_SCL) as SCL " +
                             "FROM [GroupHistoryDB].[dbo].[DIV_SPEED_HISTRECORD] where TriggerTime >= @Start and TriggerTime <= @End " +
                             "GROUP BY(DateDiff(minute, 0, [TriggerTime]) / 5) " +
                             "ORDER BY Datetime";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Start", start);
                    cmd.Parameters.AddWithValue("End", end);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt_Speed_GMCSCL.Clear();
                    da.Fill(dt_Speed_GMCSCL);
                }
                con.Close();
            }
        }

        public DataTable dtP601_Event = new DataTable();
        public DataTable dtP604_Event = new DataTable();
        public DataTable dtP605_Event = new DataTable();
        public DataTable dtP5M_Event = new DataTable();
        public DataTable dtBTD2_Event = new DataTable();
        public DataTable dtBTD3_Event = new DataTable();
        public DataTable dtBTD4_Event = new DataTable();
        public DataTable dtBTD5_Event = new DataTable();
        public DataTable dtD650_Event = new DataTable();
        public DataTable dtD750_Event = new DataTable();
        public DataTable dtD1000_Event = new DataTable();
        public DataTable dtD1100_Event = new DataTable();
        public DataTable dtGMC1_Event = new DataTable();
        public DataTable dtGMC2_Event = new DataTable();
        public DataTable dtSCL_Event = new DataTable(); 
        public void Query_Event(string mc, DateTime start, DateTime end)
        {
            if (SQL_Connected)
            {
                con.Open();
                string sql = "SELECT [Datetime],[Event] FROM [VisingPackMMS].[dbo].[" + mc + "_PO_Event] " +
                             "where Datetime >= @Start and Datetime <= @End order by Datetime desc";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Start", start);
                    cmd.Parameters.AddWithValue("End", end);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    switch (mc)
                    {
                        case "P601":
                            dtP601_Event.Clear();
                            da.Fill(dtP601_Event);
                            break;
                        case "P604":
                            dtP604_Event.Clear();
                            da.Fill(dtP604_Event);
                            break;
                        case "P605":
                            dtP605_Event.Clear();
                            da.Fill(dtP605_Event);
                            break;
                        case "P5M":
                            dtP5M_Event.Clear();
                            da.Fill(dtP5M_Event);
                            break;
                        case "BTD2":
                            dtBTD2_Event.Clear();
                            da.Fill(dtBTD2_Event);
                            break;
                        case "BTD3":
                            dtBTD3_Event.Clear();
                            da.Fill(dtBTD3_Event);
                            break;
                        case "BTD4":
                            dtBTD4_Event.Clear();
                            da.Fill(dtBTD4_Event);
                            break;
                        case "BTD5":
                            dtBTD5_Event.Clear();
                            da.Fill(dtBTD5_Event);
                            break;
                        case "D650":
                            dtD650_Event.Clear();
                            da.Fill(dtD650_Event);
                            break;
                        case "D750":
                            dtD750_Event.Clear();
                            da.Fill(dtD750_Event);
                            break;
                        case "D1000":
                            dtD1000_Event.Clear();
                            da.Fill(dtD1000_Event);
                            break;
                        case "D1100":
                            dtD1100_Event.Clear();
                            da.Fill(dtD1100_Event);
                            break;
                        case "GMC1":
                            dtGMC1_Event.Clear();
                            da.Fill(dtGMC1_Event);
                            break;
                        case "GMC2":
                            dtGMC2_Event.Clear();
                            da.Fill(dtGMC2_Event);
                            break;
                        case "SCL":
                            dtSCL_Event.Clear();
                            da.Fill(dtSCL_Event);
                            break;
                    }                    
                }
                con.Close();
            }
        }
    }
}
