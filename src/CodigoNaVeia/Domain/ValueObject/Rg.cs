namespace Domain.ValueObject
{
    public class Rg
    {
 

        public static bool Validate(string rg)
        {
            if (rg.Length != 9)
                return false;
            switch (rg)

            {
                case "000000000":

                    return false;

                case "111111111":

                    return false;


                case "22222222":

                    return false;

                case "333333333":

                    return false;

                case "444444444":

                    return false;

                case "555555555":

                    return false;

                case "666666666":

                    return false;

                case "777777777":

                    return false;

                case "888888888":

                    return false;

                case "999999999":

                    return false;

                case "123456789":
                    return false;
            }
            return true;
        }

    }
}