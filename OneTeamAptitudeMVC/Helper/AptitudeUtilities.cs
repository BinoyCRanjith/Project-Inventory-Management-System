using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OneTeamAptitudeMVC.Helper
{
    public static class AptitudeUtilities
    {
        public static string GetJSON(object obj)
        {
            string output = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return output;
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T To<T>( string json)
        {
            //JsonSerializerSettings settings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static DataTable Datafill(params object[] args)
        {
            string connectionString = OneTeamApptitudeConstantClasss.connectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(args[0].ToString(), con);
            //parameter args[1]....etcs are parameters in the order
            //parameter_name1,parameter_value1,....parameter_Name n,parameter_Value n
            for (int i = 1; i < args.Length; i++)
            {
                cmd.Parameters.AddWithValue(args[i].ToString(), args[i + 1].ToString());
                //connectionString = "Data Source=ONETEAM\SQLEXPRESS;Initial Catalog=SchoolApp;Integrated Security=True"
                i++;
            }
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            ada.Fill(ds);
            con.Close();

            return ds;


        }


        public static Boolean SaveDataToTable(params object[] args)//parameter args[0] is the stored procedure Name
        {
            string connectionString = OneTeamApptitudeConstantClasss.connectionString;
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(args[0].ToString(), con);
                //parameter args[1]....etcs are parameters in the order
                //parameter_name1,parameter_value1,....parameter_Name n,parameter_Value n
                for (int i = 1; i < args.Length; i++)
                {
                    cmd.Parameters.AddWithValue(args[i].ToString(), args[i + 1].ToString());

                    i++;
                }
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }
        public static void DeleteData(params object[] args)
        {
          
            string connectionString = OneTeamApptitudeConstantClasss.connectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(args[0].ToString(), con);
            //parameter args[1]....etcs are parameters in the order
            //parameter_name1,parameter_value1,....parameter_Name n,parameter_Value n
            con.Open();

            for (int i = 1; i < args.Length; i++)
            {
                cmd.Parameters.AddWithValue(args[i].ToString(), args[i + 1].ToString());
                //connectionString = "Data Source=ONETEAM\SQLEXPRESS;Initial Catalog=SchoolApp;Integrated Security=True"
                i++;
            }
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();


        }


        public static Boolean SendMail(string msgsubject, String msgbody, string sendTo)
        {
            try
            {

                var fromAddress = new MailAddress("xxxx.com");
                var fromPassword = "xxxx";
                var toAddress = new MailAddress(sendTo);

                string subject = msgsubject;

                string body = msgbody;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })


                    smtp.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }





    }
}