using Dapper;
using DojoLeague.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DojoLeague.Factories
{
	public class DojoFactory : IFactory<Ninja>
	{
		private string connectionString;
		
		public DojoFactory()
		{
			connectionString = "server=localhost;userid=root;password=root;port=3306;database=DojoLeague;SslMode=None";
		}

		internal IDbConnection connection
		{
			get
			{
				return new MySqlConnection(connectionString);
			}
		}



		public IEnumerable<Dojo> SelectAll()
		{
			using (IDbConnection dbCon = connection)
			{
				string query =
				@"
				SELECT * FROM `dojos`;
				";
				dbCon.Open();
				return dbCon.Query<Dojo>(query);
			}
		}

		public void Add(Dojo dojo)
		{
			using (IDbConnection dbCon = connection)
			{
				string query =
				@"
				INSERT INTO dojos (name, location, additionalInfo)
				VALUES (@Name, @Location, @AdditionalInfo);
				";
				dbCon.Open();
				dbCon.Execute(query, dojo);
			}
		}

		public Dojo FindById(int id)
		{
			using (IDbConnection dbCon = connection)
			{
				dbCon.Open();
				return dbCon.Query<Dojo>("SELECT * FROM dojos WHERE id = @Id", new { Id = id }).FirstOrDefault();
			}
		}
	}
}