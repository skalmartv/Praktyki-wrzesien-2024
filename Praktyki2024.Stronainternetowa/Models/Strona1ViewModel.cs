namespace Praktyki2024.Stronainternetowa.Models
{
    public class Strona1ViewModel
    {
        public string Pod1 { get; set; }
        public string Pod2 { get; set; }
        public string Pod3 { get; set; }
        public string Pod4 { get; set; }
        public string Pod5 { get; set; }

        public Strona1ViewModel(string pod1, string pod2, string pod3, string pod4, string pod5)
        {
            this.Pod1 = pod1;
            this.Pod2 = pod2;
            this.Pod3 = pod3;
            this.Pod4 = pod4;
            this.Pod5 = pod5;
        }
    }
}