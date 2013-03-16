using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.UnitTests
{
    public class CalculatorTestConventionsAttribute : AutoDataAttribute
    {
        public CalculatorTestConventionsAttribute()
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {

        }
    }
}
