using ShopPatterns.core.enteties;
using ShopPatterns.features.shop_main.domain.usecases.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPatterns.features.shop_main.domain.usecases.Director
{
    public class Director
    {
        private IBuilder _builder;
        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        public void fillMinimalInformationForOffer()
        {
            _builder.SetName();
            _builder.SetDeliveryAdress();
            _builder.setProducts();
        }
    }
}
