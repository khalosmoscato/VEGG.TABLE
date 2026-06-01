using System;
using System.Collections.Generic;
using System.Text;

namespace VEGG.TABLE.UnitTests.Resources;

internal class DummyUsers
{
    public static readonly List<User> testUsers =
        new List<User>
        {
                            new User
                            {
                                Id = 1,
                                Name = "VegManDan",
                                Email = "bossman@live.co.uk",
                                Password = "highthere",
                                UserType = UserType.Buyer
                            },
                             new User
                            {
                                Id = 2,
                                Name = "VegManDan2",
                                Email = "bossman2@live.co.uk",
                                Password = "highthere2",
                                UserType = UserType.Buyer
                            }
        };

    public static readonly List<User> testUsers2 =
        new List<User>
        {
                            new User
                            {
                                Id = 1,
                                Name = "Dylan",
                                Email = "Dylan@regex",
                                UserType = UserType.Buyer,
                                Password = "password",
                            },
                             new User
                            {
                                Id = 2,
                                Name = "VegManDan2",
                                Email = "bossman2@live.co.uk",
                                Password = "highthere2",
                                UserType = UserType.Buyer

                                 
                            }
        };
}