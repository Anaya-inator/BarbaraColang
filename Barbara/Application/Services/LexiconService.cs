using Barbara.Application.Interfaces;
using Barbara.Domain.Models;

namespace Barbara.Application.Services;

public class LexiconService : ILexiconService
{
	private readonly List<LexicalEntry> _entries = new();

	public IReadOnlyCollection<LexicalEntry> GetAll()
		=> _entries.AsReadOnly();

	public void Add(LexicalEntry entry)
	{
		if (entry == null)
			throw new ArgumentNullException(nameof(entry));

		if (string.IsNullOrWhiteSpace(entry.Word))
			throw new ArgumentException("Word cannot be empty.");

		_entries.Add(entry);
	}

	public bool Remove(Guid id)
	{
		var entry = _entries.FirstOrDefault(e => e.Id == id);

		if (entry == null)
			return false;

		_entries.Remove(entry);
		return true;
	}

	public bool Remove(LexicalEntry entry)
	{
		if (entry == null)
			return false;

		_entries.Remove(entry);
		return true;
	}

	public List<LexicalEntry> Search(string query)
	{
		if (string.IsNullOrWhiteSpace(query))
			return new List<LexicalEntry>();

		query = query.Trim();

		return _entries
			.Where(e =>
				e.Word.Contains(query, StringComparison.OrdinalIgnoreCase) ||
				e.Conlang.Contains(query, StringComparison.OrdinalIgnoreCase))
			.ToList();
	}
}
