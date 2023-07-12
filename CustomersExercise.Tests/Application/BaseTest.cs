using AutoMapper;
using CustomersExercise.Application.Mappings;
using System.Threading;

namespace CustomersExercise.Tests.Application
{
    public class BaseTest
    {
        public IMapper _mapper;
        public CancellationToken _cancellationToken;

        public BaseTest()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomerProfile());
            });
            _mapper = config.CreateMapper();
            var tcs = new CancellationTokenSource(-1);
            _cancellationToken = tcs.Token;           
        }
       
    }
}
