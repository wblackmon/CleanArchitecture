﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;

public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetLeaveTypeDetailsQueryHandler> _logger;

    public GetLeaveTypeDetailsQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper, IAppLogger<GetLeaveTypeDetailsQueryHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

        // Verify that the entity exists
        if (leaveType == null)
        {
            throw new NotFoundException(nameof(LeaveType), request.Id);
        }

        // Convert
        var data = _mapper.Map<LeaveTypeDetailsDto>(leaveType);

        _logger.LogInformation("Retrieved Leave Type {Id}", request.Id);
        // Return the result
        return data;


    }
}
