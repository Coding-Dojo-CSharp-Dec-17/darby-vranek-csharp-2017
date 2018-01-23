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

		public IEnumerable<Dojo> SelectAllDojos()
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
				dbCon.Execute(query, new { Name = ninja.Name, Level = ninja.Level, Description = ninja.Description, Dojo_Id = ninja.Dojo.Id });
			}
		}

		public Ninja FindById(int id)
		{
			using (IDbConnection dbCon = connection)
			{
				dbCon.Open();
				string query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id WHERE dojos.id = ninjas.dojo_id AND ninjas.id = {id};";
				Ninja nin = dbCon.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.Dojo = dojo; return ninja; }).FirstOrDefault();
				return nin;
			}
		}

		public Dojo FindDojoById(int id)
		{
			using (IDbConnection dbCon = connection)
			{
				dbCon.Open();
				return dbCon.Query<Dojo>("SELECT * FROM dojos WHERE id = @Id", new { Id = id }).FirstOrDefault();
			}
		}
	}
}