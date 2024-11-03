namespace Data.Models.CoverageModels
{
    public static class MathUtils
    {
        public const double PI = Math.PI;
        public const double Deg2Rad = PI / 180.0;

        public static double ToRadians(double degrees)
        {
            return degrees * Deg2Rad;
        }

        public const double CoverageRadiusInMeters = 100;
    }

}
