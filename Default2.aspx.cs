using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        const string sql = @"SELECT [PostCommentRowID]
                              ,[UrlQueryString]
                          FROM [be_PostComment]";
        const string sql2 = @"UPDATE [be_PostComment]
                               SET [UrlQueryString] = '{1}'
                             WHERE [PostCommentRowID] = {0}";

        string conString = System.Configuration.ConfigurationManager.ConnectionStrings["BlogEngine"].ConnectionString;

        Dictionary<int, string> lookup = new Dictionary<int, string>();


        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string q = reader.GetString(1);

                        if (q.IndexOf("&") > 0)
                        {
                            string[] parts = q.Split("&".ToCharArray());
                            if (parts.Length > 0)
                                q = parts[0];
                        }

                        lookup.Add(id, q);
                    }
                }
            }
        }

        foreach (int key in lookup.Keys)
        {
            string s = string.Format(sql2, key, lookup[key]);
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(s, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}