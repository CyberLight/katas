using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.UnitTests
{
    public class FizzBuzzTestConventionsAttribute : AutoDataAttribute
    {
        public FizzBuzzTestConventionsAttribute() 
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
