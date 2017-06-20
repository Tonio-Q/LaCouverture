using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary2
{
    public class ClassOne
    {

            DataSet ds = new DataSet();
            static String ConString = Validation_Connection.ConString();
            private static SqlConnection conn = new SqlConnection(ConString);

            #region private variables and public encapsulated variables for user accounts
            private String fname, lname, email, password, account_type, account_id;

            public String Account_id
            {
                get { return account_id; }
                set { account_id = value; }
            }
            private int user_id;


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
            private string item_name, category_name, item_img;

            public string Category_name
            {
                get { return category_name; }
                set { category_name = value; }
            }

            public string Item_img
            {
                get { return item_img; }
                set { item_img = value; }
            }

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
            private int transaction_id, trans_item_qty, subtransaction_id,
                        userQuantity, item_bought, back_itemQty;
            private decimal total_bought;

            public decimal Total_bought
            {
                get { return total_bought; }
                set { total_bought = value; }
            }

            public int Back_itemQty
            {
                get { return back_itemQty; }
                set { back_itemQty = value; }
            }

            public int Item_bought
            {
                get { return item_bought; }
                set { item_bought = value; }
            }

            public int UserQuantity
            {
                get { return userQuantity; }
                set { userQuantity = value; }
            }

            public int Subtransaction_id
            {
                get { return subtransaction_id; }
                set { subtransaction_id = value; }
            }

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
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspGetItemList", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = category_id;
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds, "_uspGetItemList");
                cmd.ExecuteNonQuery();
                conn.Close();
                return ds;
            }

            public void _uspDeleteNullTransact()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspDeleteNullTransact", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();
                
            }

            public DataSet _uspGetAccounts()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspGetAccounts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds, "_uspGetAccounts");
                cmd.ExecuteNonQuery();
                conn.Close();
                return ds;
            }
            public DataSet _uspGetUserIDandAccountID()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspGetUserIDandAccountID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds, "_uspGetUserIDandAccountID");
                cmd.ExecuteNonQuery();
                conn.Close();
                return ds;
            }


            public DataSet _uspGetTransaction()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspGetTransaction", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds, "_uspGetTransaction");
                cmd.ExecuteNonQuery();
                conn.Close();
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
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspEditItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = item_id;
                cmd.Parameters.Add("@item_name", SqlDbType.VarChar).Value = item_name;
                cmd.Parameters.Add("@item_price", SqlDbType.Decimal).Value = item_price;
                cmd.Parameters.Add("@item_qty", SqlDbType.Int).Value = item_qty;
                cmd.Parameters.Add("@item_img", SqlDbType.VarChar).Value = item_img;
                cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = category_id;
                cmd.ExecuteNonQuery();
                conn.Close();

            }

            public void _uspInsertAdmin()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspInsertAdmin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = account_id;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = fname;
                cmd.Parameters.Add("@lastname", SqlDbType.VarChar).Value = lname;
                cmd.Parameters.Add("@user_id", SqlDbType.Int).Value = user_id;
                cmd.ExecuteNonQuery();
                conn.Close();

            }


            public void _uspDeleteAccount()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspDeleteAccount", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = Convert.ToString(account_id);
                cmd.ExecuteNonQuery();
                conn.Close();

            }

            public void _uspDeleteItem()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspDeleteItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = Convert.ToInt32(item_id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            public void _uspDeleteCategory()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspDeleteCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = Convert.ToInt32(category_id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
   

            public void _uspAddItem()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspAddItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
              //  cmd.Parameters.Add("@Item_id", SqlDbType.Int).Value = Convert.ToInt32(item_id+1);
                cmd.Parameters.Add("@Item_name", SqlDbType.VarChar).Value = item_name;
                cmd.Parameters.Add("@Item_price", SqlDbType.Decimal).Value = Convert.ToDecimal(item_price);
                cmd.Parameters.Add("@Item_qty", SqlDbType.Int).Value = Convert.ToInt32(item_qty);
                cmd.Parameters.Add("@Category_ID", SqlDbType.Int).Value = Convert.ToInt32(category_id);
                cmd.Parameters.Add("@Item_img", SqlDbType.VarChar).Value = item_img;
                cmd.ExecuteNonQuery();
                conn.Close();
            
            }

            public void _uspAddCategory()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspAddCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@category_name", SqlDbType.VarChar).Value = category_name;
                //cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = Convert.ToInt32(category_id);
                cmd.ExecuteNonQuery();
                conn.Close();
            
            }

            public DataSet _uspSearchItem()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspSearchItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@item_id", SqlDbType.VarChar).Value = item_id;
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds, "_uspSearchItem");
                return ds;
                conn.Close();
            }

            public DataSet _uspSelectLast()
            {
                SqlCommand cmd = new SqlCommand("_uspSelectLast", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds, "_uspSelectLast");
                return ds;
            }

            public void _uspSubTransaction()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspSubTransaction", conn);
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@SubTransaction_ID", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@Transaction_ID", SqlDbType.Int).Value = Convert.ToInt32(transaction_id);
                cmd.Parameters.Add("@Item_ID", SqlDbType.Int).Value = Convert.ToInt32(item_id);
                cmd.Parameters.Add("@Item_Name", SqlDbType.VarChar).Value = Convert.ToString(item_name);
                cmd.Parameters.Add("@ITEM_PRICE", SqlDbType.Decimal).Value = Convert.ToDecimal(item_price);
                //cmd.Parameters.Add("@ITEM_IMG", SqlDbType.VarChar).Value = Convert.ToString(item_img);
                //cmd.Parameters.Add("@category_id", SqlDbType.Int).Value = Convert.ToInt32(category_id);
                cmd.ExecuteNonQuery();
                conn.Close();

            }

        //login if(Cpassword==Cpassword)
            public void _uspInsertTransaction()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspInsertTransaction", conn);
                cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@transaction_id", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@account_id", SqlDbType.NVarChar).Value = account_id;
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            public void _uspMinusQty()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspMinusQty", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = Convert.ToInt32(item_id);
                cmd.Parameters.Add("@item_bought", SqlDbType.Int).Value = Convert.ToInt32(item_bought);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            public void _uspUpdateCheckOut()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspUpdateCheckOut", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@subTransaction_id", SqlDbType.Int).Value = Convert.ToInt32(subtransaction_id);
                cmd.Parameters.Add("@item_bought", SqlDbType.Int).Value = Convert.ToInt32(item_bought);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            public void _uspUpdateTransaction()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspUpdateTransaction", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Transaction_ID", SqlDbType.Int).Value = Convert.ToInt32(transaction_id);
                cmd.Parameters.Add("@total_bought", SqlDbType.Decimal).Value = Convert.ToDecimal(total_bought);
                cmd.ExecuteNonQuery();
                conn.Close();
            }   


        //login if(Cpassword==Cpassword)
            public DataSet _uspMaxTransaction_id()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspMaxTransaction_ID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds.Clear();
                da.Fill(ds, "_uspMaxTransaction_ID");
                return ds;
                conn.Close();
            }

            public DataSet _uspGetAccount_ID()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspGetAccount_ID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspGetAccount_ID");
                return ds;
                conn.Close();
            }


            public DataSet _uspTransactionTotal()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspTransactionTotal", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@transaction_id", SqlDbType.NVarChar).Value = transaction_id;
                cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspTransactionTotal");
                return ds;
                conn.Close();
            }

            




            public DataSet _uspCheckOut()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspCheckOut", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@transaction_id", SqlDbType.Int).Value = transaction_id;
                cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspCheckOut");
                return ds;
                conn.Close();
            }

            public DataSet _uspUserQuantity()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspUserQuantity", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@subtransaction_id", SqlDbType.Int).Value = subtransaction_id;
                cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspUserQuantity");
                return ds;
                conn.Close();
            }

            public DataSet _uspGetItem()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspGetItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = item_id;
                cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspGetItem");
                return ds;
                conn.Close();
            }

            public DataSet _uspDeleteCOItem()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspDeleteCOItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = item_id;
                cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspDeleteCOItem");
                return ds;
                conn.Close();
            }

            public DataSet _uspBackStock()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspBackStock", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@item_id", SqlDbType.Int).Value = item_id;
                cmd.Parameters.Add("@item_qty", SqlDbType.Int).Value = back_itemQty;
                cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspBackStock");
                return ds;
                conn.Close();
            }

            public DataSet _uspGetCheckOut()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspGetCheckOut", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@subtransaction_id", SqlDbType.Int).Value = subtransaction_id;
                cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspGetCheckOut");
                return ds;
                conn.Close();
            }
            
            public DataSet _uspDeleteCheckOutItem()
            {
                conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand("_uspDeleteCheckOutItem", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //cmd.Parameters.Add("@subtransaction_id", SqlDbType.Int).Value = Convert.ToInt32(Subtransaction_id);
                //cmd.ExecuteNonQuery();
                ds.Clear();
                da.Fill(ds, "_uspDeleteCheckOutItem");
                return ds;
                conn.Close();
            }
            
            
            
        
    }
}
