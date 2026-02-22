using Barbara.Domain.Models;

namespace Barbara.Application.Interfaces
{
	public interface ILexiconService
	{
		IReadOnlyCollection<LexicalEntry> GetAll();
		bool Insert(LexicalEntry entry);
		bool Add(LexicalEntry entry);
		bool Update(LexicalEntry entry);
		bool Remove(LexicalEntry entry);
		List<LexicalEntry> Search(string query);
	}
}
