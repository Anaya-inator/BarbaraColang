using System.Runtime.Versioning;
using Barbara.Application.Interfaces;
using Barbara.Domain.Models;

namespace Barbara.Application.Services;

public class LexiconService : ILexiconService
{
	private readonly List<LexicalEntry> _entries = new();

	public IReadOnlyCollection<LexicalEntry> GetAll() => _entries.AsReadOnly();

	#region MÉTODOS

	public bool Insert(LexicalEntry entry)
	{
		return Update(entry) || Add(entry);
	}

	public bool Add(LexicalEntry entry)
	{
		if (_entries.Contains(entry))
		{
			return false;
		}	

		_entries.Add(entry);
		return true;
	}

	public bool Update(LexicalEntry entry)
	{
		int index = _entries.IndexOf(entry);

		if (index < 0)
		{
			return false;
		}
		
		_entries[index] = entry;
		return true;
	}

	public bool Remove(LexicalEntry entry)
	{
		return _entries.Remove(entry);
	}

	public List<LexicalEntry> Search(string query)
	{
		if (string.IsNullOrWhiteSpace(query))
		{
			return new List<LexicalEntry>();
		}

		query = query.Trim();

		return _entries
			.Where(e =>
				e.Word.Contains(query, StringComparison.OrdinalIgnoreCase) ||
				e.Conlang.Contains(query, StringComparison.OrdinalIgnoreCase))
			.ToList();
	}

	#endregion
}
