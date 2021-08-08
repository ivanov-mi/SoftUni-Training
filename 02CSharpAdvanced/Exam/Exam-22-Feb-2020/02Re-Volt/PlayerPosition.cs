namespace Re_Volt
{
    public class PlayerPosition
    {
        public PlayerPosition()
        { }
        public PlayerPosition(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        public int Row { get; set; }
        public int Col { get; set; }  
    }
}