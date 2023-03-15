namespace WordsCombiner.Shared.Utility
{
    public class RandomNumbers
    {
        static void Swap(ref int m, ref int n)
        {
            int work = m;
            m = n;
            n = work;
        }

        // ダステンフェルドのアルゴリズム

        public static IEnumerable<int> GetUniqRandomNumbers(int rangeBegin, int rangeEnd, int count)
        {
            // 指定された範囲の整数を格納できる配列を用意する
            int[] work = new int[rangeEnd - rangeBegin + 1];

            // 配列を初期化する
            for (int n = rangeBegin, i = 0; n <= rangeEnd; n++, i++)
                work[i] = n;

            // ランダムに取り出しては先頭から順に置いていく（count回繰り返す）
            var rnd = new Random();
            for (int resultPos = 0; resultPos < count; resultPos++)
            {
                // （resultPosを含めて）resultPosの後ろからランダムに1つ選ぶ
                int nextResultPos = rnd.Next(resultPos, work.Length);

                // nextResultPosの値をresultPosと入れ替える
                Swap(ref work[resultPos], ref work[nextResultPos]);
            }

            return work.Take(count); // workの先頭からcount個を返す
        }
    }
}
