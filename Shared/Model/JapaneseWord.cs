using System.ComponentModel.DataAnnotations;

namespace WordsCombiner.Shared.Model
{
    public class JapaneseWord
    {
        /// <summary>
        /// 単語。
        /// </summary>
        [Key]
        public string Value { get; set; } = string.Empty;
        
        /// <summary>
        /// 品詞。
        /// </summary>
        public int PartOfSpeech { get; set; }
    }
}