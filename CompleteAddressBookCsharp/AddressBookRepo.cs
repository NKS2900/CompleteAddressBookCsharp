using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookApp
{
    public class AddressBookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=addressbook_service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public bool EstablishConnection()
        {
            try
            {
                using (this.connection)
                {
                    connection.Open(); 
                    Console.WriteLine("Database_Connected_Successfully....");
                    return true;
                    connection.Close();
                }
            }
            catch
            {
                Console.WriteLine("Database_NOT_Connected!!!");
                return false;
            }
        }

        public int RetrieveContactFromPerticularAddressBook()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    int count = 0;
                    using (SqlCommand command = new SqlCommand(
                        @"SELECT * FROM address_book", connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                count++;
                                model.First_Name = reader.GetString(0);
                                model.Last_Name = reader.GetString(1);
                                model.Address = reader.GetString(2);
                                model.City = reader.GetString(3);
                                model.State = reader.GetString(4);
                                model.Zip = reader.GetString(5);
                                model.Phone_Number = reader.GetString(6);
                                model.Email = reader.GetString(7);

                                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}", model.First_Name, model.Last_Name, model.Address, model.City,
                                    model.State, model.Zip, model.Phone_Number, model.Email);
                                Console.WriteLine("\n");
                            }
                            return count;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public bool EditContactUsingFirstName(AddressBookModel model)
        {
            try
            {
                using (this.connection)
                {
                    string updateQuery = @"UPDATE address_book SET last_name = @Last_Name, city = @City, state = @State, email = @Email, bookname = @BookName, addressbooktype = @AddressbookType WHERE first_name = @First_Name;";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@First_Name", model.First_Name);
                    command.Parameters.AddWithValue("@Last_Name", model.Last_Name);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@Email", model.Email);
                    command.Parameters.AddWithValue("@BookName", model.BookName);
                    command.Parameters.AddWithValue("@AddressbookType", model.AddressbookType);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Contact Updated successfully...");
                    this.connection.Close();
                    return true;
                }
               
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
    }
}
