namespace Praktyki2024.Stronainternetowa.Models
{
    public class Strona3ViewModel
    {
        public string Pod111 { get; set; }
        public string Pod211 { get; set; }
        public string Pod311 { get; set; }
        public string Pod411 { get; set; }
        public string Pod511 { get; set; }

        public Strona3ViewModel(string pod111, string pod211, string pod311, string pod411, string pod511)
        {
            this.Pod111 = pod111;
            this.Pod211 = pod211;
            this.Pod311 = pod311;
            this.Pod411 = pod411;
            this.Pod511 = pod511;
        }
    }
}