namespace MetaMeals.Web.Utility
{
    public class StaticData
    {

       public static String CouponAPIBase { get; set; }
       public  enum ApiType { 
        
            GET,
            POST,
            PUT,
            DELETE,
       }
    }
}
