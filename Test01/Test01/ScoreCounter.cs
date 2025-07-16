namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);

        }

        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {
            var scores = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(',');
                //Saleオブジェクトを生成
                var score = new Student() {
                    StudentName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                scores.Add(score);

            }

            return scores;




        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var score in _score) {
                if (dict.ContainsKey(score.StudentName))
                    dict[score.StudentName] += score.Amount;
                else
                    dict[score.StudentName] = score.Amount;

            }
            return dict;




        }
    }
}
