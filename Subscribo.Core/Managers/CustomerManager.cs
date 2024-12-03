﻿using Microsoft.Extensions.Logging;
using Orleans;
using Subscribo.Core.Abstractions.Enums;
using Subscribo.Core.Abstractions.Interfaces.Managers;
using Subscribo.Core.Abstractions.Models;
using Subscribo.Core.Abstractions.Models.Requests;
using Subscribo.Core.Abstractions.Models.Responses;
using Subscribo.Grains.Exceptions;
using Subscribo.Grains.Interfaces;

namespace Subscribo.Core.Managers
{
    public class CustomerManager(ILogger<CustomerManager> logger ,IClusterClient clusterClient) : ICustomerManager
    {
        public Task<ApiResponse<int>> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<Customer>> GetByIdAsync(int customerId, CancellationToken cancellationToken)
        {
            try
            {
                var customerGrain = clusterClient.GetGrain<ICustomerGrain>(customerId);
                var customer = await customerGrain.GetById();
                return ApiResponse<Customer>.Success(customer, ResponseCode.Success);
            }
            catch (EntityNotFoundException e) 
            {
                string errorMessage = $"{nameof(CustomerManager)} - {nameof(GetByIdAsync)} failed with error: {e.Message}";
                logger.LogWarning(errorMessage);
                return ApiResponse<Customer>.Fail(e.Message, ResponseCode.NotFound);
            }
            catch (Exception e) 
            {
                string errorMessage = $"{nameof(CustomerManager)} - {nameof(GetByIdAsync)} failed with error: {e.Message}";
                logger.LogError(errorMessage);
                return ApiResponse<Customer>.Fail(e.Message, ResponseCode.InternalServerError);
            }
        }
    }
}