using Barbara.Domain.Models;

namespace Barbara.Application.Interfaces
{
	public interface ILexiconService
	{
		IReadOnlyCollection<LexicalEntry> GetAll();
		void Add(LexicalEntry entry);
		bool Remove(Guid id);
		bool Remove(LexicalEntry entry);
		List<LexicalEntry> Search(string query);
	}
}
