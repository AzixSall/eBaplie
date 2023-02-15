namespace eBaplie.Helpers
{
    public class ParserHelper
    {
        public DateTime ConvertDateTime(string value)
        {
            try
            {
                int yyyy = Int32.Parse(value.Substring(0, 4));
                int MM = Int32.Parse(value.Substring(4, 2));
                int dd = Int32.Parse(value.Substring(6, 2));

                return new DateTime(yyyy, MM, dd);
            }
            catch (Exception)
            {
                int yyyy = Int32.Parse(value.Substring(0, 2));
                int MM = Int32.Parse(value.Substring(2, 2));
                int dd = Int32.Parse(value.Substring(4, 2));

                return new DateTime(yyyy, MM, dd);
            }
        }

        //200618:1220
        public DateTime Convert2DateTime(string value)
        {
            int yyyy = 2000 + Int32.Parse(value.Substring(0, 2));
            int MM = Int32.Parse(value.Substring(2, 2));
            int dd = Int32.Parse(value.Substring(4, 2));
            int hh = Int32.Parse(value.Substring(7, 2));
            int mm = Int32.Parse(value.Substring(9, 2));

            return new DateTime(yyyy, MM, dd, hh, mm, 00);
        }

        public string[] GetSegments(string corior)
        {
            string[] tab = corior.Split(char.Parse("'"));

            return tab;
        }
        public string[] GetElements(string segment)
        {
            string[] tab = segment.Split(char.Parse("+"));

            return tab;
        }
        public string[] GetComponent(string element)
        {
            string[] tab = element.Split(char.Parse(":"));

            return tab;
        }
    }
}
