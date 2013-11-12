namespace InstantBingo.ViewModels
{
    public class PatternCountViewModel
    {
        public string Name { get; set; }
        public bool[][] Patterns { get; set; }
        public int Count { get; set; }

        public PatternCountViewModel(string name, bool[][] patterns)
        {
            Name = name;
            Patterns = patterns;
        }        
    }
}
