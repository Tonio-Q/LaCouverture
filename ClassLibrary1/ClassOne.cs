using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace ClassLibrary1
{
    public class ClassOne
    {
        DataSet ds = new DataSet();
        static String ConString = Validation_Connection.ConString();
        private static SqlConnection conn = new SqlConnection(ConString);

        #region private variables and public encapsulated variables for user accounts
        private String fname, lname, email, password, account_type;
        private int user_id, account_id;

        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }
        public String Fname
        {
            get { return fname; }
            set { fname = value; }
        }

        public String Lname
        {
            get { return lname; }
            set { lname = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        
        #endregion
       
        #region privates variable and encapsulated variables for items
        private int item_id, item_qty, category_id;
        private double item_price;
        private string item_name, category_name;

        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }


        public double Item_price
        {
            get { return item_price; }
            set { item_price = value; }
        }
        
        public int Category_id
        {
            get { return category_id; }
            set { category_id = value; }
        }

        public int Item_qty
        {
            get { return item_qty; }
            set { item_qty = value; }
        }

        public int Item_id
        {
            get { return item_id; }
            set { item_id = value; }
        }
        

        #endregion

        #region private variable and encapsulated variables for transaction
        private int transaction_id, trans_item_qty;

        public int Trans_item_qty
        {
            get { return trans_item_qty; }
            set { trans_item_qty = value; }
        }

        public int Transaction_id
        {
            get { return transaction_id; }
            set { transaction_id = value; }
        }

        #endregion

        
       
        public DataSet _uspGetItemList()
        {
            SqlCommand cmd = new SqlCommand("_uspGetItemList", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "_uspGetItemList");
            return ds;
        }

        public DataSet _uspGetCategory()
        {
            SqlCommand cmd = new SqlCommand("_uspGetCategory", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds.Clear();
            da.Fill(ds, "_uspGetCategory");
            return ds;
        }

        public void _uspEditItem()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("_uspEditItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = item_id;
            cmd.Parameters.Add("@item_name", SqlDbType.VarChar).Value = item_name;
            cmd.Parameters.Add("@item_price", SqlDbType.Decimal).Value = item_price;
            cmd.Parameters.Add("@item_qty", SqlDbType.Int).Value = item_qty;
            cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = category_id;
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void _uspMinusQty()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("_uspMinusItem", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = item_id;
            cmd.Parameters.Add("@item_qty", SqlDbType.Int).Value = item_qty;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
