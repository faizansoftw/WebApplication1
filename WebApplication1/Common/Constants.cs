namespace WebApplication1.Common
{
    public static class Constants
    {
        public enum Plans : short
        {
            SMHW = 1,
            SMHD = 2,
            SMHDW = 3,
            SMHP = 4,
            SMHCC = 5
        }

        public enum Status : short
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3
        }
    }
}
