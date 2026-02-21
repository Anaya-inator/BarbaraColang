using System.ComponentModel.DataAnnotations;

namespace Barbara.Domain.Models;

public class LexicalEntry
{
	public Guid Id { get; set; } = Guid.NewGuid();

	[Required]
	[StringLength(50)]
	public string Word { get; set; } = string.Empty;

	[StringLength(50)]
	public string Conlang { get; set; } = string.Empty;

	public WordType? WordType { get; set; } = null;

	[StringLength(100)]
	public string Pronunciation { get; set; } = string.Empty;

	[StringLength(700)]
	public string Definition { get; set; } = string.Empty;

	public List<LexicalEntry> Etimology { get; set; } = new();
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
