using lost_in_the_woods.Models;
using System.Collections.Generic;
namespace lost_in_the_woods.Factory
{
	public interface IFactory<T> where T : BaseEntity {}
}