using System.Collections.Generic;

namespace Model
{
    public class QuizViewModel
    {
        public Pokemon CorrectAnswer { get; set; }
        public IEnumerable<string> FakeAnswers { get; set; }
    }
}
