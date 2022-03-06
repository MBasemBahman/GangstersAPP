namespace EConnectSocialMedia.ServiceEntity
{
    public static class OrderBy<T>
    {
        public static List<T> OrderData(List<T> items, string OrderString)
        {
            if (!string.IsNullOrEmpty(OrderString))
            {
                string[] OrderByProp = OrderString.Split(",");

                foreach (string item in OrderByProp)
                {
                    string Prop = item;
                    bool Desc = Prop.Contains("desc");

                    Prop = Prop.Replace("desc", "");
                    Prop = Prop.Replace(",", "");
                    Prop = Prop.Trim();

                    System.Reflection.PropertyInfo propertyInfo = typeof(T).GetProperty(Prop.FirstCharToUpper());

                    if (propertyInfo != null)
                    {
                        items = (Desc == true) ?
                            items.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList() :
                            items.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();
                    }
                }
            }

            return items;
        }

        public static IQueryable<T> OrderData(IQueryable<T> items, string OrderString)
        {
            if (!string.IsNullOrEmpty(OrderString))
            {
                string[] OrderByProp = OrderString.Split(",");

                foreach (string item in OrderByProp)
                {
                    string Prop = item;
                    bool Desc = Prop.Contains("desc");

                    Prop = Prop.Replace("desc", "");
                    Prop = Prop.Replace(",", "");
                    Prop = Prop.Trim();

                    System.Reflection.PropertyInfo propertyInfo = typeof(T).GetProperty(Prop.FirstCharToUpper());

                    if (propertyInfo != null)
                    {
                        items = (Desc == true) ?
                            items.OrderByDescending(x => propertyInfo.GetValue(x, null)) :
                            items.OrderBy(x => propertyInfo.GetValue(x, null));
                    }
                }
            }

            return items;
        }

        public static IQueryable<T> Randomize(IQueryable<T> items)
        {
            return items.OrderBy(_ => Guid.NewGuid());
        }
    }

    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            return input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
            };
        }
    }
}
