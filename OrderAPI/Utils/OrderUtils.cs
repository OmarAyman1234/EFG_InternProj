namespace OrderAPI.Utils
{
    public class OrderUtils
    {
        public static string NormalizeDirection(string dir)
        {
            //if (dir.ToLower().Trim() == "b" || dir.ToLower().Trim() == "buy")
            //    return "Buy";
            //if (dir.ToLower().Trim() == "s" || dir.ToLower().Trim() == "sell")
            //    return "Sell";
            //throw new Exception("Direction can only be Buy or Sell!");

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
