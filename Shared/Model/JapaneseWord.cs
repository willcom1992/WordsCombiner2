using System.ComponentModel.DataAnnotations;

namespace WordsCombiner.Shared.Model
{
    public class JapaneseWord
    {
        [Key]
        public string Value { get; set; } = string.Empty;
        public int PartOfSpeech { get; set; }
    }
}