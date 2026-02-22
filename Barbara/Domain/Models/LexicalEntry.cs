using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Barbara.Domain.Models;

public class LexicalEntry : IEquatable<LexicalEntry>
{
	public Guid Id { get; set; } = Guid.NewGuid();

	[StringLength(50)]
	public string Word { get; set; } = string.Empty;

	[StringLength(50)]
	public string Conlang { get; set; } = string.Empty;

	public WordType? WordType { get; set; } = null;

	[StringLength(100)]
	public string Pronunciation { get; set; } = string.Empty;

	[StringLength(700)]
	public string Definition { get; set; } = string.Empty;

	public HashSet<LexicalEntry> Etimology { get; set; } = new HashSet<LexicalEntry>();

	public bool Equals(LexicalEntry? other)
	{
		if (other is null) return false;
		if (ReferenceEquals(this, other)) return true;

		return Id == other.Id;
	}

	public override bool Equals(object? obj)
		=> Equals(obj as LexicalEntry);

	public override int GetHashCode()
		=> Id.GetHashCode();
}

public enum WordType
{
	Noun,
	Verb,
	Adjective,
	Adverb,
	Pronoun,
	Preposition,
	Conjunction,
	Interjection,
	Article,
}
