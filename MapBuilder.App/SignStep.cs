namespace MapBuilder.App
{
    public struct SignStep
    {
        public int Floor { get; set; }
        public int Section { get; set; }

        public SignStep(int floor, int section) 
        {
            Floor = floor;
            Section = section;
        }
    }
}