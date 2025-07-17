namespace OrderAPI.Domain
{
    public static class OrderUtils
    {
        public static string NormalizeDirection(string dir)
        {
            var direction = dir.ToLower().Trim();
            return direction switch
            {
                "b" or "buy" => "Buy",
                "s" or "sell" => "Sell",
                _ => throw new Exception("Direction can only be Buy or Sell!")
            };
        }
    }
} 