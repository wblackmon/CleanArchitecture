using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

    public GetLeaveTypesQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IAppLogger<GetLeaveTypesQueryHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveTypes = await _leaveTypeRepository.GetAllAsync();

        // Verify that the entity exists
        if (leaveTypes == null)
        {
            _logger.LogWarning("No Leave Types were found");
            throw new NotFoundException(nameof(LeaveType));
        }

        // Map the results to a list of LeaveTypeDto
        var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

        // Return the result
        _logger.LogInformation("Retrieved all Leave Types");
        return data;
    }
}
