using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypes;
using CleanArchitecture.Application.MappingProfiles;
using CleanArchitecture.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.UnitTests.Features.LeaveTypes.Queries
{
    public class GetLeaveTypeListQueryHandlerTests
    {
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockIAppLogger;
        private IMapper _mapper;
        public GetLeaveTypeListQueryHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();
            _mockIAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LeaveTypeProfile>();
            });
            
            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypesListTest()
        {
            var handler = new GetLeaveTypesQueryHandler(_mockRepo.Object, _mapper, _mockIAppLogger.Object);

            var result = await handler.Handle(new GetLeaveTypesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }


    }
}
