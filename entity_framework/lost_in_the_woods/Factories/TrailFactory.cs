using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using lost_in_the_woods.Models;

namespace lost_in_the_woods.Factory
{
	public class TrailFactory : IFactory<Trail>
	{
		private string connectionString;

		public TrailFactory()
		{
			connectionString = "server=localhost;userid=root;password=root;port=3306;database=lost_in_the_woods;SslMode=None";
		}

		internal IDbConnection connection
		{
			get 
			{
				return new MySqlConnection(connectionString);
			}
		}

		public void Add(Trail trail)
		{
			using (IDbConnection dbConnection = connection)
			{
				string query = "INSERT INTO trails (name, description, trail_length, elevation_change, latitude, longitude) VALUES (@Name, @Description, @Trail_Length, @Elevation_Change, @Latitude, @Longitude);";
				dbConnection.Open();
				dbConnection.Execute(query, trail);
			}
		}

		public IEnumerable<Trail> SelectAll()
		{
			using (IDbConnection dbConnection = connection)
			{
				dbConnection.Open();
				return dbConnection.Query<Trail>("SELECT * FROM trails");
			}
		}

		public Trail FindById(int id)
		{
			using (IDbConnection dbConnection = connection)
			{
				dbConnection.Open();
				return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
			}
		}
	}
}