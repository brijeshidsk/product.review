using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFullWebAPI.Tests.MoqDemo
{
    public interface IThingDependency
    {
        string Join(string st1, string st2);
        int Age { get; }

        bool Charge(int amount, Card card);

    }

    public class Card {
        public string Name { get; set; }
        public int Number { get; set; }
        public int CVV { get; set; }

    }

    public class ThingDependency: IThingDependency
    {
        public int Age => throw new NotImplementedException();

        public bool Charge(int amount, Card card)
        {
            return true;
        }

        public string Join(string st1, string st2)
        {
            throw new NotImplementedException();
        }
    }

    public class ThingToBeTested
    {
        IThingDependency _dep;

        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public ThingToBeTested(IThingDependency dep)
        {
            _dep = dep;
        }
        public string doTheThing()
        {
            var name = _dep.Join(Firstname, Lastname);
            return $"{name} is {_dep.Age} years old";
        }

        public bool chargeTheCard(int amount , Card card)
        {
            return _dep.Charge(amount, card);
        }


    }

}
