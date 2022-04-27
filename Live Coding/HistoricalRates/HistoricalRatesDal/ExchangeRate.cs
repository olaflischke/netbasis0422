using System.Data.SqlClient; // ADO.NET für SQL-Server

namespace HistoricalRatesDal
{
    public class ExchangeRate
    {
        public string Symbol { get; set; }
        public double EuroRate { get; set; }

        #region POCO-Implemntierung
        public int Id { get; set; }

        public ExchangeRate()
        {

        }

        public ExchangeRate(int id)
        {
            // SELECT * FROM ExchangeRate WHERE ID = id

            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    //try
                    //{
                    connection.Open();

                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "SELECT * FROM ExchangeRate WHERE ID = @Id",
                        Connection = connection
                    };

                    SqlParameter parId = new SqlParameter("@Id", id);
                    command.Parameters.Add(parId);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        this.Id = id;
                        this.EuroRate = Convert.ToDouble(reader["Rate"]);
                        this.Symbol = reader["Symbol"].ToString();
                    }

                    //}
                    //catch (Exception)
                    //{

                    //    throw;
                    //}           
                    //finally
                    //{
                    //    connection?.Close();
                    //}
                }

            }
            catch (Exception)
            {

                throw;
            }      
        }

        public void Save()
        {
            if (this.Id==0)
            {
                // INSERT
                SqlCommand command = new SqlCommand() { CommandText = "INSeRT INTO Rates...." };


                //  ID aus der Datenbank holen
                SqlCommand cmdGetId = new SqlCommand() { CommandText = "SELECT Ident_Current('Rates')" };
                this.Id = cmdGetId.ExecuteNonQuery();

            }
            else
            {
                // UPDATE
            }
        }


        public void Delete()
        {

        }
        #endregion
    }
}