using System.ComponentModel.DataAnnotations;

namespace WordsCombiner.Shared
{
    /// <summary>
    /// 品詞。
    /// </summary>
    public enum PartOfSpeech
    {
        /// <summary>
        /// 名詞。
        /// </summary>
        [Display(Name = "名詞", Order = 0)]
        Noun,

        /// <summary>
        /// 動詞。
        /// </summary>
        [Display(Name = "動詞", Order = 1)]
        Verb,

        /// <summary>
        /// 形容詞。
        /// </summary>
        [Display(Name = "形容詞", Order = 2)]
        Adjective,
    }
}
