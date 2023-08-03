namespace Employee_Info.api.Request
{
    public class QueryParameters
    {
        const int _MaxSize = 100;
        private int _Size = 50;
        public int Page { get; set; } = 1;
        public int Size
        {
            get { return _Size; }
            set { _Size = Math.Min(_MaxSize, value); }
        }
    }
}
