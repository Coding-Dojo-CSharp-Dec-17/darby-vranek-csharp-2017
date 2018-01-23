using Dapper;
using DojoLeague.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DojoLeague.Factories
{
	public class NinjaFactory : IFactory<Ninja>
	{
		private string connectionString;
		
		public NinjaFactory()
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



		public IEnumerable<Ninja> SelectAll()
		{
			using (IDbConnection dbCon = connection)
			{
				string query =
				@"
				SELECT * FROM `ninjas`;
				";
				dbCon.Open();
				return dbCon.Query<Ninja>(query);
			}
		}

		public void Add(Ninja ninja)
		{
			using (IDbConnection dbCon = connection)
			{
				string query =
				@"
				INSERT INTO ninjas (name, level, description, dojo_id)
				VALUES (@Name, @Level, @Description, @Dojo_Id);
				";
				dbCon.Open();
				dbCon.Execute(query, ninja);
			}
		}
	}
}