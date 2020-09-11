using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Oblig1;

namespace NUnitTestProjectOblig1
{
    class FamilyAppTests
    {
        [Test]
        public void TestChildren()
        {

            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("show 3");
            var expectedResponse = "Haakon Magnus (Id=3) Født: 1973 Far: Harald (Id=6)\n"
                                   + "  Barn:\n"
                                   + "    Sverre Magnus (Id=1) Født: 2005\n"
                                   + "    Ingrid Alexandra (Id=2) Født: 2004\n";


            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [Test]
        public void TestNoChildren()
        {


            var marius = new Person { Id = 5, FirstName = "Marius", BirthYear = 1997 }; ;
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            marius.Father = haakon;

            var app = new FamilyApp(marius);
            var actualResponse = app.HandleCommand("show 5");
            var expectedResponse = "Marius (Id=5) Født: 1997 Far: Haakon Magnus (Id=3) ";



            Assert.AreEqual(expectedResponse, actualResponse);
        }
    }
}
