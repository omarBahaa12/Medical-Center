using Data.data;
namespace BusinessLogic
{
    public static class CrudExtiention
    {
        public static bool Add <TSource>(this TSource source,Predicate<TSource> predicate)
        {
            if (predicate is null)
                return false;
            if (source is null)
                return false;
            using()
            {

            }
        }
    }
}
