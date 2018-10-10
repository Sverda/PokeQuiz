using System.Collections.Generic;

namespace Model.Dto
{
    public class QuizDto
    {
        public Pokemon CorrectAnswer { get; set; }
        public IEnumerable<string> FakeAnswers { get; set; }
    }
}
