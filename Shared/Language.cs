using System.ComponentModel.DataAnnotations;

namespace WordsCombiner.Shared
{
    /// <summary>
    /// 言語。
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// 日本語。
        /// </summary>
        [Display(Name = "日本語", Order = 0)]
        Japanese,

        /// <summary>
        /// 英語。
        /// </summary>
        [Display(Name = "英語", Order = 0)]
        English,
    }
}
